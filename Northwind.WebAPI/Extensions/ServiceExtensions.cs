using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Repositories;
using Northwind.Persistence;
using Northwind.Persistence.Base;

namespace Northwind.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
           services.AddCors(options =>
           {
               options.AddPolicy("CorsPolicy", builder =>
                   builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());
           });

        // add IIS configure options deploy to IIS
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {
            });

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryDbContext>(opts =>
        {
            opts.UseSqlServer(configuration.GetConnectionString("ShopeeConnection"));
        });

        //create a service once per request
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
          services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}
