using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using OrderService.Application.Features.Commands.OrderCommands.ReserveOrder;
using System.Threading.Tasks;

namespace OrderService.API.Consumers
{
    public class OrderReversedEventConsumer
        : IConsumer<OrderReversedEvent>
    {
        private IMediator _mediator;

        public OrderReversedEventConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<OrderReversedEvent> context)
        {
            await _mediator.Send(new ReserveOrderCommand { OrderId = context.Message.OrderId });
        }
    }
}
