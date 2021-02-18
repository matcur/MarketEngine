using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Data.Models
{
    public class Goods
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public long CurrencyId { get; set; }

        public long CountryId { get; set; }

        public Currency Currency { get; set; }

        public Country Country { get; set; }

        public List<GoodsCategory> Categories { get; set; }
    }
}
