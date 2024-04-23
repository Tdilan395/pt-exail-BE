using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tienda.Application.Auth.Dto;
using tienda.Application.Pedidos;
using tienda.Domain.Entities;
using tienda.Domain.Repositories;

namespace tienda.Application.Auth
{
    internal class AuthService(IAuthRepository authRepository, ILogger<PedidosService> logger) : IAuthService
    {
        public async Task<Usuario> Login(Login login)
        {
            try
            {
                return await authRepository.Login(new Usuario() { Nombre = login.Username, Clave = login.Password });
            }
            catch (Exception ex)
            {
                logger.LogError($"Error al logear {ex.Message}");
                return null;
            }
        }

        public async Task<Usuario> Register(Register regis)
        {
            try
            {
                return await authRepository.Register(new Usuario() { Nombre = regis.Nombre, Clave = regis.Clave, Correo = regis.Correo });
            }
            catch (Exception ex)
            {
                logger.LogError($"Error al Registrar {ex.Message}");
                return null;
            }
        }

    }
}
