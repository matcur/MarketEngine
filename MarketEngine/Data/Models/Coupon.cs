using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Data.Models
{
    public class Coupon
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public int DiscountPercent
        {
            get => discountPrice;
            set
            {
                if (value > 100 || value < 1)
                    throw new ArgumentException("Dicsount percent must be between 100 and 1(excludly)");

                discountPrice = value;
            }
        }

        public long GoodsId { get; set; }

        public Goods Goods { get; set; }

        private int discountPrice;

        public double CalculateDicsount()
        {
            return Goods.Price * DiscountPercent / 100;
        }
    }
}
