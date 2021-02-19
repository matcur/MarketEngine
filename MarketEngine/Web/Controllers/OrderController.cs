using MarketEngine.Core.GoodsCart;
using MarketEngine.Data;
using MarketEngine.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly Cart cart;

        private readonly DbSet<Order> orderTable;

        public OrderController(Cart cart, MarketContext marketContext)
        {
            this.cart = cart;
            orderTable = marketContext.Orders;
        }

        [HttpGet]
        [Route("/order")]
        public IActionResult Index()
        {
            var orders = orderTable.Include(o => o.OrderItems)
                      .ThenInclude(i => i.Goods)
                      .ToList();

            return View(orders);
        }

        [HttpPost]
        [Route("/order")]
        public IActionResult Create()
        {
            cart.CreateOrder();

            return RedirectToAction("Index");
        }
    }
}
