using MicroRabbit.Order.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicorRabbit.Order.Data.Context
{
    public class OrderDbContext: DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options): base(options)
        {

        }
        public DbSet<Order1> Orders { get; set; }
    }
}
