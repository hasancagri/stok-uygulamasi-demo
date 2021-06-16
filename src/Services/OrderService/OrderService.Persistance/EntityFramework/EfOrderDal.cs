using OrderService.Application.Contracts.Persistance;
using OrderService.Domain.Entities;

namespace OrderService.Persistance.EntityFramework
{
    public class EfOrderDal
        : EfEntityRepositoryBase<Order>, IOrderDal
    {
        public EfOrderDal(OrderContext context)
            : base(context)
        {
        }
    }
}
