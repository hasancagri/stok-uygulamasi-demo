using MediatR;
using StockService.Domain.Entities;

namespace StockService.Application.Features.Queries.StockQueries.GetStockByProductId
{
    public class GetStockByProductIdQuery
         : IRequest<Stock>
    {
        public int ProductId { get; set; }
    }
}
