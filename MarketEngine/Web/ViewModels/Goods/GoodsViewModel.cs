using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Web.ViewModels.Goods
{
    public class GoodsViewModel
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public List<IFormFile> Images { get; set; }

        public IFormFile Thumbnail { get; set; }
    }
}
