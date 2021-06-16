using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using StockService.Application.Features.Commands.StockCommands.ChangeStockQuantity;
using StockService.Application.Features.Queries.StockQueries.GetStockByProductId;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StockService.API.Consumers
{
    public class OrderCreatedEventConsumer
        : IConsumer<OrderCreatedEvent>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMediator _mediator;

        public OrderCreatedEventConsumer(IPublishEndpoint publishEndpoint, IMediator mediator)
        {
            _publishEndpoint = publishEndpoint;
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var stock = await _mediator
                .Send(new GetStockByProductIdQuery { ProductId = context.Message.ProductId });
            if (context.Message.Quantity > stock.StockCount)
            {
                await _publishEndpoint.Publish(new OrderReleasedEvent
                {
                    OrderId = context.Message.OrderId
                });
            }
            else
            {
                stock.StockCount -= context.Message.Quantity;
                await _mediator.Send(new ChangeStockQuantityCommand
                {
                    Stock = stock
                });

                var orderReversedEvent = new OrderReversedEvent
                {
                    OrderId = context.Message.OrderId,
                };

                await _publishEndpoint.Publish(orderReversedEvent);
            }
        }
    }
}
