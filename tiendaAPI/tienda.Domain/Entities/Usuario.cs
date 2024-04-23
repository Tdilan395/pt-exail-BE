using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }

    }
}
