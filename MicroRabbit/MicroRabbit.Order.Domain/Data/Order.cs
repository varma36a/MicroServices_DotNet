using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicroRabbit.Order.Domain.Data
{
    public class Order1
    {
        [Key]
        public Guid OrderId { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
    }
}
