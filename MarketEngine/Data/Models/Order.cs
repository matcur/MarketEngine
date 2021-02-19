using MarketEngine.Infrastructure.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Data.Models
{
    public class Order
    {
        public long Id { get; set; }

        public long CustomerId { get; set; }

        [NotMapped]
        public double Price
        {
            get 
            {
                var result = 0d;
                foreach (var order in OrderItems)
                    result += order.Price;

                return result;
            }
        }

        public PaymentStatus PaymentStatus { get; set; }

        public MarketUser Customer { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
