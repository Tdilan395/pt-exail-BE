using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tienda.Domain.Entities;
using tienda.Domain.Repositories;
using tienda.Infrastructure.Persistence;

namespace tienda.Infrastructure.Repositories
{
    internal class ProductosRepository(TiendaDbContext dbContext): IProductosRepository
    {
        public async Task AddAsync(Producto producto)
        {
            try
            {
                await dbContext.productos.AddAsync(producto);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al guardar el producto en la base de datos.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var producto = await dbContext.productos.FindAsync(id);
                if (producto != null)
                {
                    dbContext.productos.Remove(producto);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al eliminar el producto de la base de datos.", ex);
            }
        }

        public async Task<Producto> Get(int id)
        {
            try
            {
                var product = await dbContext.productos.FindAsync(id);
                if (product == null) { throw new InvalidOperationException("No se encontró el producto."); }
                return product;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener el producto de la base de datos.", ex);
            }
        }

        public async Task<IEnumerable<Producto>> GetAllAsync() { 
            var productos = await dbContext.productos.ToListAsync();   
            return productos;
        }

        public async Task<IEnumerable> getProductosAsync(List<int> ids)
        {
            var productos = await dbContext.productos.Where(p=>ids.Contains(p.Id)).ToListAsync();
            return productos;
        }

        public async Task UpdateAsync(Producto producto)
        {
            try
            {
                dbContext.productos.Entry(producto).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al actualizar el producto en la base de datos.", ex);
            }
        }
    }
}
