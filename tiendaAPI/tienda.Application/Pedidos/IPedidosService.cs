using tienda.Application.Pedidos;

namespace tienda.Application.Pedidos
{
    public interface IPedidosService
    {
        Task<bool> AddPedidoAsync(PedidoDto pedido);
    }
}