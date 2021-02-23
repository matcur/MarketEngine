using MarketEngine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Core.GoodsCart
{
    public class GoodsSet
    {
        public Goods Goods { get; }

        public long Count { get; set; }

        public double Price
        {
            get
            {
                var discount = 0d;
                if (EnteredCoupon != null)
                    discount = EnteredCoupon.CalculateDicsount();

                return (Goods.Price - discount) * Count;
            }
        }

        public Coupon? EnteredCoupon { get; set; }

        public GoodsSet(Goods goods, long count)
        {
            if (goods == null)
                throw new ArgumentNullException("Goods can not be null");

            Goods = goods;
            Count = count;
        }

        public GoodsSet(Goods goods, long count, Coupon coupon) : this(goods, count)
        {
            EnteredCoupon = coupon;
        }
    }
}
