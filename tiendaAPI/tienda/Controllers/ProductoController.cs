using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using tienda.Application.Productos;
using tienda.Domain.Entities;
using tienda.Domain.Repositories;

namespace tienda.Controllers
{
    [ApiController]
    [Route("api/Productos")]
    [Authorize]
    public class ProductoController(IProductosService productosService): ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public async  Task<IActionResult> GetAll() { 
            var productos = await productosService.GetAllProductos();
            if (productos.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await productosService.GetProductoByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        // POST: api/productos
        [HttpPost]
        [Route("AddProducto")]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            if(User.FindFirstValue(ClaimTypes.NameIdentifier)!="Admin")return Unauthorized();

            var status = await productosService.AddProductoAsync(producto);
            if(!status)return BadRequest("No se agregó el producto");
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }

        // PUT: api/productos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != "Admin") return Unauthorized();
            if (id != producto.Id)
            {
                return BadRequest("No se editó el producto");
            }
            await productosService.UpdateProductoAsync(producto);
            return Ok("Editado con exito");
        }

        // DELETE: api/productos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != "Admin") return Unauthorized();
            await productosService.DeleteProductoAsync(id);
            return Ok("Eliminado con exito");
        }
    }
}
