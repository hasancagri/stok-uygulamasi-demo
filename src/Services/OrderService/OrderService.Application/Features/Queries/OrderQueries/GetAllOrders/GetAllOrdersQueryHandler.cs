using MediatR;
using OrderService.Application.Contracts.Persistance;
using OrderService.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Queries.OrderQueries.GetAllOrders
{
    public class GetAllOrdersQueryHandler
         : IRequestHandler<GetAllOrdersQuery, List<Order>>
    {
        private readonly IOrderDal _orderDal;

        public GetAllOrdersQueryHandler(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public async Task<List<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderDal.GetList();
        }
    }
}
