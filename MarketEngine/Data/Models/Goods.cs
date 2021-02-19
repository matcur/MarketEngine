using MarketEngine.Web.ViewModels.Goods;
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
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public long CurrencyId { get; set; }

        public long CountryId { get; set; }

        public Currency Currency { get; set; }

        public Country Country { get; set; }

        public List<GoodsCategory> Categories { get; set; } = new List<GoodsCategory>();
    }
}
