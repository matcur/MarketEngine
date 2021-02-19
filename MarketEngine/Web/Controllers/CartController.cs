using MarketEngine.Core.GoodsCart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly Cart cart;

        public CartController(Cart cart)
        {
            this.cart = cart;
        }

        [Route("/cart/content")]
        public IActionResult Index()
        {
            return View(cart);
        }
    }
}
