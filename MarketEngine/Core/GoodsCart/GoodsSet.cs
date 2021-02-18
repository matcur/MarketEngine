using MarketEngine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Core.GoodsCart
{
    public class GoodsSet
    {
        public Goods Goods { get; }

        public long Count { get; set; }

        public double Price => Goods.Price * Count;

        public GoodsSet(Goods goods, long count)
        {
            if (goods == null)
                throw new ArgumentNullException("Goods can not be null");

            Goods = goods;
            Count = count;
        }
    }
}
