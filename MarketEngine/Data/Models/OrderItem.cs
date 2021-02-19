using MarketEngine.Core.GoodsCart;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Data.Models
{
    public class OrderItem
    {
        public OrderItem() { }

        public OrderItem(GoodsSet set)
        {
            GoodsCount = set.Count;
            GoodsId = set.Goods.Id;
        }

        public long Id { get; set; }

        public long GoodsCount { get; set; }

        [NotMapped]
        public double Price => Goods.Price * GoodsCount;

        public long OrderId { get; set; }

        public long GoodsId { get; set; }

        public Goods Goods { get; set; }

        public Order Order { get;set; }
    }
}
