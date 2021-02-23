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
    public class GoodsController : Controller
    {
        private readonly MarketContext marketContext;

        private readonly DbSet<Goods> goodsTable;

        public GoodsController(MarketContext marketContext)
        {
            this.marketContext = marketContext;
            goodsTable = marketContext.Goods;
        }

        [HttpGet]
        [Route("/goods")]
        public IActionResult Index()
        {
            return View(goodsTable.ToList());
        }

        [HttpGet]
        [Route("/goods/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/goods/create")]
        public IActionResult Create(GoodsViewModel goodsViewModel)
        {
            goodsTable.Add(new Goods(goodsViewModel));
            marketContext.SaveChanges();

            return View();
        }

        [HttpGet]
        [Route("/goods/{id:long}")]
        public IActionResult Details(long id)
        {
            var goods = goodsTable.First(g => g.Id == id);

            return View(new GoodsSetViewModel(new GoodsSet(goods, 0)));
        }
    }
}
