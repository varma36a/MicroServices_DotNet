using MicroRabbit.Order.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroRabbit.Order.Application
{
    public interface IOrderDataAccess
    {
        List<Order1> GetAllOrder();
        void SaveOrder(Order1 order);
        Order1 GetOrder(Guid orderId);
        Task<bool> DeleteOrder(Guid orderId);
    }
}
