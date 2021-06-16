using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using OrderService.Application.Features.Commands.OrderCommands.ReleaseOrder;
using System.Threading.Tasks;

namespace OrderService.API.Consumers
{
    public class OrderReleasedEventConsumer
        : IConsumer<OrderReleasedEvent>
    {
        private IMediator _mediator;

        public OrderReleasedEventConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<OrderReleasedEvent> context)
        {
            await _mediator.Send(new ReleaseOrderCommand { Id = context.Message.OrderId });
        }
    }
}
