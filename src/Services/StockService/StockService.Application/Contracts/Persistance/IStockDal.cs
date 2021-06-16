using StockService.Domain.Entities;

namespace StockService.Application.Contracts.Persistance
{
    public interface IStockDal
        : IEntityRepository<Stock>
    {
    }
}
