using OrderService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrderService.Application.Contracts.Persistance
{
    public interface IEntityRepository<T>
          where T : EntityBase
    {
        Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<int> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
