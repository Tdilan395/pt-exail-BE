using tienda.Application.Auth.Dto;
using tienda.Domain.Entities;

namespace tienda.Application.Auth
{
    public interface IAuthService
    {
        Task<Usuario> Login(Login login);
        Task<Usuario> Register(Register regis);
    }
}