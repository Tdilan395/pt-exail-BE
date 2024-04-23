using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tienda.Domain.Entities;

namespace tienda.Domain.Repositories
{
    public interface IAuthRepository
    {
        Task<Usuario> Login(Usuario usuario);
        Task<Usuario> Register(Usuario usuario);
    }
}
