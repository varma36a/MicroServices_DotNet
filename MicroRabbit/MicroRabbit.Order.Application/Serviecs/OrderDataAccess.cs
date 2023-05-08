using MicorRabbit.Order.Data.Context;
using MicroRabbit.Order.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroRabbit.Order.Application
{
    public class OrderDataAccess : IOrderDataAccess
    {
        OrderDbContext context;
        public OrderDataAccess(OrderDbContext _context)
        {
            context = _context;
        }
        public List<Order1> GetAllOrder()
        {
            return context.Orders.ToList();
        }
        public void SaveOrder(Order1 order)
        {
            context.Add(order);
            context.SaveChanges();
        }

        public async Task<bool> DeleteOrder(Guid orderId)
        {
            Order1 order = context.Orders.Where(x => x.OrderId == orderId).FirstOrDefault();

            if (order != null)
            {
                context.Remove(order);
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Order1 GetOrder(Guid orderId)
        {
            return context.Orders.Where(x => x.OrderId == orderId).FirstOrDefault();
        }
    }
}
