using MassTransit;
using MicroRabbit.Order.Application;
using Shared.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Api.Consumers
{
    public class OrderCancelledConsumer : IConsumer<IOrderCancelled>
    {
        private IOrderDataAccess _orderDataAccess;
        public OrderCancelledConsumer(IOrderDataAccess orderDataAccess)
        {
            _orderDataAccess = orderDataAccess;
        }
        public async Task Consume(ConsumeContext<IOrderCancelled> context)
        {
            var data = context.Message;
            await _orderDataAccess.DeleteOrder(data.OrderId);
        }
    }
}
