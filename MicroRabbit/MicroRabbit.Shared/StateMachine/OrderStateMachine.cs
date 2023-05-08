using MassTransit;
using Shared.DbCOnfiguration;
using Shared.Messages.Events;
using System;

namespace Shared.StateMachine
{
    public class OrderStateMachine : MassTransitStateMachine<OrderState>
    {
        public OrderStateMachine()
        {
            Event(() => OrderStated, x => x.CorrelateById(m => m.Message.OrderId));
            Event(() => OrderCancelled, x => x.CorrelateById(m => m.Message.OrderId));

            InstanceState(x => x.CurrentState);

            Initially(
                   When(OrderStated)
                   .Then(ctx =>
                   {
                       ctx.Saga.OrderCreationDateTime = DateTime.Now;
                       ctx.Saga.OrderId = ctx.Message.OrderId;
                       ctx.Saga.Product = ctx.Message.Product;
                       ctx.Saga.Price = ctx.Message.Price;
                   })
                   .TransitionTo(Started)
                   .Publish(ctx => new OrderValidate(ctx.Saga)));

            During(Started, When(OrderCancelled)
                   .Then(ctx => ctx.Saga.OrderCancelDateTime = DateTime.Now)
                   .TransitionTo(Cancelled));
        }

        public State Started { get; set; }
        public State Cancelled { get; set; }
        public Event<IOrderStarted> OrderStated { get; set; }
        public Event<IOrderCancelled> OrderCancelled { get; set; }
    }
}
