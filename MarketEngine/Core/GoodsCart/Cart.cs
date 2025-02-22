﻿using MarketEngine.Data;
using MarketEngine.Data.Models;
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

        private readonly MarketContext db;

        private readonly IMemoryCache cache;
        
        private readonly string id;

        public Cart(IMemoryCache cache, IHttpContextAccessor contextAccessor, MarketContext db)
        {
            this.cache = cache;
            this.db = db;
            var sessionId = contextAccessor.HttpContext.Request.Cookies[".AspNetCore.Session"];
            id = $"Goods-Card-{sessionId}";
            InitializeGoodsSets();
        }

        public void AddGoods(Goods goods, long count)
        {
            AddGoodsSet(new GoodsSet(goods, count));
        }

        public void AddGoodsSet(GoodsSet set)
        {
            if (HasGoods(set.Goods))
                throw new ArgumentException($"{set.Goods.Name} already in cart");

            goodsSets.Add(set);
            CacheGoodsSets();
        }

        public void UpdateGoodsCount(Goods goods, long count)
        {
            if (!HasGoods(goods))
                throw new ArgumentException($"{goods.Name} doesn't exists in cart");

            FindGoodsSet(goods).Count = count;
            CacheGoodsSets();
        }

        public void RemoveGoodsSet(GoodsSet set)
        {
            if (!goodsSets.Contains(set))
                throw new ArgumentException($"Goods with name {set.Goods.Name} not found");

            goodsSets.Remove(set);
            CacheGoodsSets();
        }

        public bool HasGoods(Goods goods)
        {
            return goodsSets.Exists(s => s.Goods.Id == goods.Id);
        }

        public GoodsSet FindGoodsSet(Goods goods)
        {
            return goodsSets.Find(s => s.Goods.Id == goods.Id);
        }

        public Order CreateOrder()
        {
            var order = MakeOrder();

            db.Orders.Add(order);
            db.SaveChanges();

            return order;
        }

        public Order MakeOrder()
        {
            var order = new Order();
            foreach (var set in goodsSets)
                order.OrderItems.Add(new OrderItem(set));

            return order;
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
