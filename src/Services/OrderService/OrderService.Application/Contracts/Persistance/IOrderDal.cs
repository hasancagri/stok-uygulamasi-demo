using OrderService.Domain.Entities;

namespace OrderService.Application.Contracts.Persistance
{
    public interface IOrderDal
        : IEntityRepository<Order>
    {
    }
}
