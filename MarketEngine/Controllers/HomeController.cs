﻿using MarketEngine.Data;
using MarketEngine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Controllers
{
    public class HomeController : Controller
    {
        private readonly MarketContext marketContext;

        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger, MarketContext marketContext)
        {
            this.marketContext = marketContext;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

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
