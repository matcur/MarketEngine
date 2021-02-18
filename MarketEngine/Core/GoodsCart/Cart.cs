using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Core.GoodsCart
{
    public class Cart
    {
        public IReadOnlyList<GoodsSet> GoodsSets => goodsSets;

        public double TotalPrice
        {
            get
            {
                var result = 0d;
                goodsSets.ForEach(set => result += set.Price);

                return result;
            }
        }

        private List<GoodsSet> goodsSets = new List<GoodsSet>();

        private readonly string id;

        private readonly IMemoryCache cache;

        public Cart(IMemoryCache cache, IHttpContextAccessor contextAccessor)
        {
            this.cache = cache;
            var sessionId = contextAccessor.HttpContext.Request.Cookies[".AspNetCore.Session"];
            id = $"Goods-Card-{sessionId}";
            InitializeGoodsSets();
        }

        public void AddGoodsSet(GoodsSet set)
        {
            goodsSets.Add(set);
            CacheGoodsSets();
        }

        public void RemoveGoodsSet(GoodsSet set)
        {
            if (!goodsSets.Contains(set))
                throw new ArgumentException($"Goods with name {set.Goods.Name} not found");

            goodsSets.Remove(set);
            CacheGoodsSets();
        }

        private void InitializeGoodsSets()
        {
            List<GoodsSet> sets = null;
            if (cache.TryGetValue(id, out sets))
                goodsSets.AddRange(sets);
        }

        private void CacheGoodsSets()
        {
            cache.Set(id, goodsSets);
        }
    }
}
