using tienda.Domain.Entities;

namespace tienda.Application.Productos
{
    public interface IProductosService
    {
        Task<bool> AddProductoAsync(Producto producto);
        Task<bool> DeleteProductoAsync(int id);
        Task<IEnumerable<Producto>> GetAllProductos();
        Task<Producto> GetProductoByIdAsync(int id);
        Task<bool> UpdateProductoAsync(Producto producto);
    }
}