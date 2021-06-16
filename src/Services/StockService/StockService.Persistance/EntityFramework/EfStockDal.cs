using StockService.Application.Contracts.Persistance;
using StockService.Domain.Entities;
using StockService.Persistance.EntityFramework;

namespace OrderService.Persistance.EntityFramework
{
    public class EfStockDal
        : EfEntityRepositoryBase<Stock>, IStockDal
    {
        public EfStockDal(StockContext context)
            : base(context)
        {
        }
    }
}
