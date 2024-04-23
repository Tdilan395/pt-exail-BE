using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }

        public int usuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public ICollection<DetallePedido> Detalles { get; set; }

    }
}
