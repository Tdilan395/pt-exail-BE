
using Microsoft.Extensions.Logging;
using tienda.Domain.Entities;
using tienda.Domain.Repositories;

namespace tienda.Application.Productos
{
    internal class ProductosService(IProductosRepository productosRepository, ILogger<ProductosService> logger) : IProductosService
    {
        public async Task<bool> AddProductoAsync(Producto producto)
        {
            logger.LogInformation("Agregando un producto");

            try
            {
                await productosRepository.AddAsync(producto);
                logger.LogInformation("Producto agregado correctamente");
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError($"Error al agregar el producto: {ex.Message}");
                return false; 
            }
        }

        public async Task<bool> DeleteProductoAsync(int id)
        {
            logger.LogInformation("Eliminando un producto");
            try
            {
                await productosRepository.DeleteAsync(id);
                logger.LogInformation("Producto agregado correctamente");
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError($"Error al agregar el producto: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<Producto>> GetAllProductos()
        {
            logger.LogInformation("Tomando todos los productos");
            var productos = await productosRepository.GetAllAsync();
            return productos;
        }

        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            logger.LogInformation("Tomando un producto");
            var productos = await productosRepository.Get(id);
            return productos;
        }

        public async Task<bool> UpdateProductoAsync(Producto producto)
        {
            logger.LogInformation("Editando un producto");
            try
            {
                await productosRepository.UpdateAsync(producto);
                logger.LogInformation("Producto editado correctamente");
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError($"Error al editar el producto: {ex.Message}");
                return false;
            }
        }

        
    }
}
