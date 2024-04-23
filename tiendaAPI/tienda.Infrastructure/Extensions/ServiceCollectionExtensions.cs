using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using tienda.Domain.Entities;
using tienda.Domain.Repositories;
using tienda.Infrastructure.Persistence;
using tienda.Infrastructure.Repositories;

namespace tienda.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("exaltDb");
            services.AddDbContext<TiendaDbContext>(options => options.UseSqlServer(connectionString));
            
            services.AddScoped<ITiendaSeeder, TiendaSeeder>();
            services.AddScoped<IProductosRepository, ProductosRepository>();
            services.AddScoped<IPedidosRepository, PedidosRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();

        }
    }
}
