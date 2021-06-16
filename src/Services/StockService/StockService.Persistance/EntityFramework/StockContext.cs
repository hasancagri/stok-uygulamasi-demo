using Microsoft.EntityFrameworkCore;
using StockService.Domain.Entities;

namespace OrderService.Persistance.EntityFramework
{
    public class StockContext
        : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options)
            : base(options)
        {
        }

        public DbSet<Stock> Stocks { get; set; }
    }
}
