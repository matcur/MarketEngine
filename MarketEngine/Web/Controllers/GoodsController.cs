using MarketEngine.Core.GoodsCart;
using MarketEngine.Data.Models;
using MarketEngine.Web.ViewModels.Goods;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Web.Controllers
{
    public class GoodsController : Controller
    {
        private readonly Cart cart;

        private readonly List<Goods> goodsList = new List<Goods>
        {
            new Goods() { Id = 0, Name = "a", Price = 100},
            new Goods() { Id = 1, Name = "b", Price = 100},
            new Goods() { Id = 2, Name = "c", Price = 200},
            new Goods() { Id = 3, Name = "d", Price = 300},
        };

        public GoodsController(Cart cart)
        {
            this.cart = cart;
        }

        [Route("/goods")]
        [HttpGet]
        public IActionResult Index()
        {
            return View(goodsList);
        }

        [Route("/goods")]
        [HttpPost]
        public IActionResult InsertGoodsSet(GoodsSetViewModel goodsSetModel)
        {
            var goods = goodsList[(int)goodsSetModel.GoodsId];
            if (cart.HasGoods(goods))
                cart.UpdateGoodsCount(goods, goodsSetModel.Count);
            else
                cart.AddGoods(goods, goodsSetModel.Count);

            return Redirect("/");
        }
    }
}
