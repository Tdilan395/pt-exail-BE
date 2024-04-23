using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tienda.Domain.Entities;
using tienda.Domain.Repositories;
using tienda.Infrastructure.Persistence;

namespace tienda.Infrastructure.Repositories
{
    internal class PedidosRepository(TiendaDbContext dbContext):IPedidosRepository
    {

        public async Task<Pedido> AddPedido(Pedido pedido)
        {
            try
            {
                int ultimoId = await dbContext.pedidos.OrderByDescending(p => p.Id).Select(p => p.Id).FirstOrDefaultAsync();
                pedido.Id=ultimoId+1;
                await dbContext.pedidos.AddAsync(pedido);
                await dbContext.SaveChangesAsync();
                return pedido;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al guardar el pedido en la base de datos.", ex);
            }
        }

        public async Task SavePedidoDetalle(List<DetallePedido> pedidoDetalle,int pedidoID)
        {
            try
            {
                foreach (var detalle in pedidoDetalle)
                {
                    detalle.PedidoId = pedidoID;
                }

                await dbContext.detalles.AddRangeAsync(pedidoDetalle);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al guardar el pedido en la base de datos.", ex);
            }
        }
    }
}
