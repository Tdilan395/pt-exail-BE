using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tienda.Application.Pedidos;
using tienda.Domain.Entities;



namespace tienda.Controllers
{
    [ApiController]
    [Route("api/Pedidos")]
    [Authorize]
    public class PedidoController(IPedidosService pedidosService): ControllerBase
    {
        [HttpPost]
        [Route("AddPedido")]
        public async Task<ActionResult<PedidoDto>> PostPedido(PedidoDto pedido)
        {
            var status = await pedidosService.AddPedidoAsync(pedido);
            if (!status) return BadRequest("No se efectuó el pedido");
            return Ok(status);
        }
    }
}
