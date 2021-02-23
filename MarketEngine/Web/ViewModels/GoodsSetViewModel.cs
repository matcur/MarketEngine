using MarketEngine.Core.GoodsCart;
using MarketEngine.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Web.ViewModels
{
    public class GoodsSetViewModel
    {
        public long Count { get; set; }

        public string CouponCode { get; set; } = "";

        public long GoodsId { get; set; }

        public Goods Goods { get;  set; }

        public GoodsSetViewModel() { }

        public GoodsSetViewModel(GoodsSet goodsSet)
        {
            Goods = goodsSet.Goods;
            Count = goodsSet.Count;
        }
    }
}
