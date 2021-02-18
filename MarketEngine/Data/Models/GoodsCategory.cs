using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Data.Models
{
    public class GoodsCategory
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<Goods> Goods { get; set; }
    }
}
