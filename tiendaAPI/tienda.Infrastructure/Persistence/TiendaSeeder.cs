using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tienda.Domain.Entities;

namespace tienda.Infrastructure.Persistence
{
    internal class TiendaSeeder(TiendaDbContext dbContext) : ITiendaSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                var productos = GetProductos();

            }
        }

        private IEnumerable<Producto> GetProductos()
        {
            return dbContext.productos.ToList();
        }
    }

}
    