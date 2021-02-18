using MarketEngine.Core.GoodsCart;
using MarketEngine.Data;
using MarketEngine.Data.Models;
using MarketEngine.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly MarketContext marketContext;

        private readonly Cart cart;
        
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger, MarketContext marketContext, Cart cart)
        {
            this.marketContext = marketContext;
            this.cart = cart;
            this.logger = logger;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View(cart);
        }

        [Route("/privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
