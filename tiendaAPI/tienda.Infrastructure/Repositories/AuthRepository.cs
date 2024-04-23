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
    internal class AuthRepository(TiendaDbContext dbContext) : IAuthRepository
    {
        public async Task<Usuario> Login(Usuario usuario)
        {
            var user = await dbContext.usuarios.FirstOrDefaultAsync(u => u.Nombre == usuario.Nombre && u.Clave == usuario.Clave);
            return user;
        }

        public async Task<Usuario> Register(Usuario usuario)
        {
            // Verifica si el usuario ya existe en la base de datos
            var existingUser = await dbContext.usuarios.AnyAsync(u => u.Nombre == usuario.Nombre);
            if (existingUser)
            {
                return null; // Usuario ya existe
            }

            dbContext.usuarios.Add(usuario);
            await dbContext.SaveChangesAsync();
            return usuario; // Registro exitoso
        }
    }
}
