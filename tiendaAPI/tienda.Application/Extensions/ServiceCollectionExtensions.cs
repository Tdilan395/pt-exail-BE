using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tienda.Application.Pedidos;
using tienda.Application.Productos;
using tienda.Application.Auth;
using tienda.Domain.Repositories;

namespace tienda.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductosService, ProductosService>();
            services.AddScoped<IPedidosService, PedidosService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
