using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderService.Persistance.EntityFramework;
using Polly;
using System;

namespace OrderService.API.Extensions
{
    public static class HostExtension
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<OrderContext>();
                var retry = Policy.Handle<SqlException>()
                    .WaitAndRetry(retryCount: 5,
                    sleepDurationProvider: retryCount => TimeSpan.FromSeconds(Math.Pow(retryCount, 2)),
                    onRetry: (exception, context) =>
                    {
                        //Burada log işlemi yapılabilir
                    });
                retry.Execute(() => Migrate(context));
            }
            return host;
        }

        private static void Migrate(OrderContext context)
        {
            context.Database.Migrate();
        }
    }
}
