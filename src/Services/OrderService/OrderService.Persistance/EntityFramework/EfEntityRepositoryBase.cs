using Microsoft.EntityFrameworkCore;
using OrderService.Application.Contracts.Persistance;
using OrderService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrderService.Persistance.EntityFramework
{
    public class EfEntityRepositoryBase<T>
         : IEntityRepository<T>
         where T : EntityBase
    {
        private readonly OrderContext _context;
        public EfEntityRepositoryBase(OrderContext context)
        {
            _context = context;
        }

        public async Task<int> Add(T entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(T entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>()
                .FirstOrDefaultAsync(filter);
        }

        public async Task<List<T>> GetList(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? await _context.Set<T>().ToListAsync()
                : await _context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task Update(T entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
