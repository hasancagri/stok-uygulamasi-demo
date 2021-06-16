using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Persistance.EntityFramework;
using StockService.Application.Contracts.Persistance;

namespace OrderService.Persistance
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistanceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStockDal, EfStockDal>();
            services.AddDbContext<StockContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("StockContext")));
            return services;
        }
    }
}
