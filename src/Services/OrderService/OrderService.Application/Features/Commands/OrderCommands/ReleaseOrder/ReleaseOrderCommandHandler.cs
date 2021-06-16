using MediatR;
using OrderService.Application.Contracts.Persistance;
using OrderService.Application.Features.Queries.OrderQueries.GetOrderById;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Commands.OrderCommands.ReleaseOrder
{
    public class ReleaseOrderCommandHandler
         : IRequestHandler<ReleaseOrderCommand>
    {
        private readonly IMediator _mediator;
        private readonly IOrderDal _orderDal;

        public ReleaseOrderCommandHandler(IMediator mediator, IOrderDal orderDal)
        {
            _mediator = mediator;
            _orderDal = orderDal;
        }

        public async Task<Unit> Handle(ReleaseOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery { Id = request.Id });
            await _orderDal.Delete(order);
            return Unit.Value;
        }
    }
}
