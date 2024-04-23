using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tienda.Domain.Entities;

namespace tienda.Domain.Repositories
{
    public interface IPedidosRepository
    {
        Task<Pedido> AddPedido(Pedido pedido);
        Task SavePedidoDetalle(List<DetallePedido> pedido, int pedidoId);
    }
}
