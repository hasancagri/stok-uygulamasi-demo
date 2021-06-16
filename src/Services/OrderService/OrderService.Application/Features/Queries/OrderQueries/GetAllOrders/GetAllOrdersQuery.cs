using MediatR;
using OrderService.Domain.Entities;
using System.Collections.Generic;

namespace OrderService.Application.Features.Queries.OrderQueries.GetAllOrders
{
    public class GetAllOrdersQuery
          : IRequest<List<Order>>
    {
    }
}
