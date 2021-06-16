using MediatR;
using StockService.Application.Contracts.Persistance;
using StockService.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StockService.Application.Features.Queries.StockQueries.GetStockByProductId
{
    public class GetStockByProductIdQueryHandler
        : IRequestHandler<GetStockByProductIdQuery, Stock>
    {
        private readonly IStockDal _stockDal;

        public GetStockByProductIdQueryHandler(IStockDal stockDal)
        {
            _stockDal = stockDal;
        }

        public async Task<Stock> Handle(GetStockByProductIdQuery request, CancellationToken cancellationToken)
        {
            var stock = await _stockDal.Get(x => x.ProductId == request.ProductId);
            return stock;
        }
    }
}
