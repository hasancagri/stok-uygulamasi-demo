using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Application.Contracts.Persistance;
using OrderService.Persistance.EntityFramework;

namespace OrderService.Persistance
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistanceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOrderDal, EfOrderDal>();
            services.AddDbContext<OrderContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("OrderContext")));
            return services;
        }
    }
}
