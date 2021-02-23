using MarketEngine.Core.GoodsCart;
using MarketEngine.Data;
using MarketEngine.Data.Models;
using MarketEngine.Web.ViewModels;
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

        private readonly DbSet<Goods> goodsTable;

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
        public IActionResult InsertGoodsSet(GoodsSetViewModel set)
        {
            var goods = goodsTable.Include(g => g.Coupons)
                                  .First(g => g.Id == set.GoodsId);

            var enteredCode = set.CouponCode;
            if (!string.IsNullOrEmpty(enteredCode))
            {
                var coupon = goods.Coupons.First(c => c.Code == enteredCode);
                cart.AddGoodsSet(new GoodsSet(goods, set.Count, coupon));

                return Redirect("/");
            }

            if (cart.HasGoods(goods))
                cart.UpdateGoodsCount(goods, set.Count);
            else
                cart.AddGoods(goods, set.Count);

            return Redirect("/");
        }
    }
}
