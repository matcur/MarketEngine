using MarketEngine.Core.GoodsCart;
using MarketEngine.Data;
using MarketEngine.Web.ViewModels.Goods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly Cart cart;
        private readonly DbSet<Data.Models.Goods> goodsTable;

        public CartController(Cart cart, MarketContext marketContext)
        {
            this.cart = cart;
            goodsTable = marketContext.Goods;
        }

        [Route("/cart/content")]
        public IActionResult Index()
        {
            return View(cart);
        }

        [HttpPost]
        [Route("/cart/goods/{GoodsId:long}")]
        public IActionResult InsertGoodsSet(GoodsSetViewModel goodsSet)
        {
            var goods = goodsTable.First(g => g.Id == goodsSet.GoodsId);
            if (cart.HasGoods(goods))
                cart.UpdateGoodsCount(goods, goodsSet.Count);
            else
                cart.AddGoods(goods, goodsSet.Count);

            return Redirect("/");
        }
    }
}
