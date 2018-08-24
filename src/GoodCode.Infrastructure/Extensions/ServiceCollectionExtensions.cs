using GoodCode.Core.Interfaces;
using GoodCode.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GoodCode.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataStore(this IServiceCollection services,
                                               string connectionString, bool useInMemoryDatabase = false)
        {
            services.AddScoped<IAppDbContext, AppDbContext>();

            return services.AddDbContext<AppDbContext>(options =>
            {
                _ = useInMemoryDatabase
                ? options.UseInMemoryDatabase(databaseName: "GoodCode")
                : options.UseMySql(connectionString, b => b.MigrationsAssembly("GoodCode.Infrastructure"));
            });
        }
    }
}