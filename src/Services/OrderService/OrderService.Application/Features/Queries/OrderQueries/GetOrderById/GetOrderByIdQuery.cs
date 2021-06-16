using MediatR;
using OrderService.Domain.Entities;

namespace OrderService.Application.Features.Queries.OrderQueries.GetOrderById
{
    public class GetOrderByIdQuery
        : IRequest<Order>
    {
        public int Id { get; set; }
    }
}
