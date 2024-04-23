using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tienda.Application.Productos.Dtos;

namespace tienda.Application.Pedidos
{
    public class PedidoDto
    {
        public List<ProductoDto>? productosPedidos { get; set; }
        public string? Descripcion { get; set; }
    }
}
