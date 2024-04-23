using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda.Domain.Entities
{
    public class DetallePedido
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set;}

        public Producto producto { get; set; }
        public Pedido pedido { get; set; }
    }
}
