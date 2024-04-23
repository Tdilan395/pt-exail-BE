using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tienda.Application.Pedidos;
using tienda.Application.Productos.Dtos;
using tienda.Domain.Entities;
using tienda.Domain.Repositories;

namespace tienda.Application.Pedidos
{
    internal class PedidosService(IPedidosRepository pedidosRepository, IProductosRepository productosRepository, ILogger<PedidosService> logger) : IPedidosService
    {
        public async Task<bool> AddPedidoAsync(PedidoDto pedidoDtos)
        {
            logger.LogInformation("Haciendo un pedido");

            try
            {

                var productosIds = pedidoDtos.productosPedidos.Select(p=>p.ProductoId).ToList();
                List<Producto> productos = (List<Producto>) await productosRepository.getProductosAsync(productosIds);

                // Verificar stock antes de hacer el pedido
                if (!checkStock(pedidoDtos.productosPedidos, productos))
                {
                    logger.LogInformation("No hay suficiente stock para completar el pedido");
                    return false;
                }
                
                var pedido = await pedidosRepository.AddPedido(new Pedido() {
                    FechaCreacion = DateTime.Now,
                    Estado = "VIGENTE",
                });

                List<DetallePedido> pedidoDetalle = new List<DetallePedido>();
                foreach (var p in pedidoDtos.productosPedidos)
                {
                    pedidoDetalle.Add(new DetallePedido()
                    {
                        Cantidad = p.Cantidad,
                        PedidoId = pedido.Id,
                        ProductoId = p.ProductoId
                    }) ;
                }

                await pedidosRepository.SavePedidoDetalle(pedidoDetalle,pedido.Id);
                logger.LogInformation("Pedido efectuado correctamente");
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError($"Error al efectuar el pedido: {ex.Message}");
                return false;
            }
        }

        internal bool checkStock(List<ProductoDto> productosPedido, List<Producto> productos)
        {
            // Crear un diccionario de productos para una búsqueda más eficiente
            var productosDic = productos.ToDictionary(p => p.Id);

            foreach (var producto in productosPedido)
            {
                if (!productosDic.TryGetValue(producto.ProductoId, out Producto productoEnStock))
                {
                    // El producto no fue encontrado en la lista de productos disponibles
                    return false;
                }

                if (producto.Cantidad > productoEnStock.Stock)
                {
                    // No hay suficiente stock para el producto
                    return false;
                }

            }
            return true;
        }
    }
}
