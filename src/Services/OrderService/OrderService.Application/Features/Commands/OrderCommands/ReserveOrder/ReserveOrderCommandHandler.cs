using MediatR;
using OrderService.Application.Contracts.Persistance;
using OrderService.Application.Features.Queries.OrderQueries.GetOrderById;
using OrderService.Domain.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Commands.OrderCommands.ReserveOrder
{
    public class ReserveOrderCommandHandler
        : IRequestHandler<ReserveOrderCommand>
    {
        private readonly IMediator _mediator;
        private readonly IOrderDal _orderDal;

        public ReserveOrderCommandHandler(IMediator mediator, IOrderDal orderDal)
        {
            _mediator = mediator;
            _orderDal = orderDal;
        }

        public async Task<Unit> Handle(ReserveOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery { Id = request.OrderId });
            order.OrderStatus = OrderStatus.SepeteEklendi;
            await _orderDal.Update(order);
            return Unit.Value;
        }
    }
}
