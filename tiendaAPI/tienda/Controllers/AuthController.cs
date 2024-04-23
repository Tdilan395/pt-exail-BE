using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using tienda.Application.Pedidos;
using tienda.Application.Auth.Dto;
using tienda.Application.Auth;
using tienda.Domain.Entities;

namespace tienda.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(Login auth)
        {
            var user= await authService.Login(auth);
            if (user != null)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Rol.ToString()),
                    new Claim(ClaimTypes.Name, user.Nombre),
                    new Claim(ClaimTypes.Email, user.Correo)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties authProperties = new AuthenticationProperties
                {

                };

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return Ok(authProperties);
            }

            return BadRequest("not found");
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(Register usuario)
        {
            var result = await authService.Register(usuario);

            if (result!=null)
            {
                return Ok("Usuario registrado exitosamente");
            }

            return BadRequest("Error al registrar el usuario");
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("Logout exitoso");
        }
    }
}
