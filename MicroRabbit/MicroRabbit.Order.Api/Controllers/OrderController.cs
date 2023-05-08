using MassTransit;
using MicroRabbit.Order.Application;
using MicroRabbit.Order.Domain.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.BusConfiguration;
using Shared.Messages.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroRabbit.Order.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderDataAccess _orderDataAccess;
        private readonly ISendEndpointProvider _sendEndpointProvider;
        public OrderController(IOrderDataAccess orderDataAccess, ISendEndpointProvider sendEndpointProvider)
        {
            _orderDataAccess = orderDataAccess;
            _sendEndpointProvider = sendEndpointProvider;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order1 order)
        {
            _orderDataAccess.SaveOrder(order);

            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:" + BusConstants.OrderQueue));
            await endpoint.Send<IOrderInitiate>(new
            {
                OrderId = order.OrderId,
                Price = order.Price,
                Product = order.Product
            });
            return Ok("success");
        }
    }
}
