using MediatR;
using OrderService.Application.Contracts.Persistance;
using OrderService.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Queries.OrderQueries.GetOrderById
{
    public class GetOrderByIdQueryHandler
         : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOrderDal _orderDal;

        public GetOrderByIdQueryHandler(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _orderDal.Get(x => x.Id == request.Id);
        }
    }
}
