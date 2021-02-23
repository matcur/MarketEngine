using MarketEngine.Core.Extensions;
using MarketEngine.Data.Models.Files;
using MarketEngine.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Data.Models
{
    public class Goods
    {
        public Goods() { }

        public Goods(GoodsViewModel viewModel)
        {
            Name = viewModel.Name;
            Price = viewModel.Price;
            CountryId = 1;
            CurrencyId = 1;
            Images = viewModel.Images.Map(f => new GoodsFile(f));
            ThumbnailPath = new GoodsFile(viewModel.Thumbnail).Path;
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public long CurrencyId { get; set; }

        public long CountryId { get; set; }

        public string ThumbnailPath { get; set; }

        public Currency Currency { get; set; }

        public Country Country { get; set; }

        public List<Coupon> Coupons { get; set; } = new List<Coupon>();

        public List<GoodsFile> Images { get; set; } = new List<GoodsFile>();

        public List<GoodsCategory> Categories { get; set; } = new List<GoodsCategory>();
    }
}
