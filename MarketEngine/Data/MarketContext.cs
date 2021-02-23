using MarketEngine.Data.Models;
using MarketEngine.Data.Models.Files;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Data
{
    public class MarketContext : DbContext
    {
        public DbSet<Goods> Goods { get; set; }

        public DbSet<GoodsCategory> GoodsCategories { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<MarketUser> Users { get; set; }

        public DbSet<Coupon> Coupons { get; set; }

        public MarketContext(DbContextOptions options): base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
