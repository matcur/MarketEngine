using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Data.Models
{
    public class MarketUser
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
