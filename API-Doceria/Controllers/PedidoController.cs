using API_Doceria.Context;
using API_Doceria.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Doceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly DoceriaContext _doceriaContext;

        public PedidoController(DoceriaContext doceriaContext)
        {
            _doceriaContext = doceriaContext;
        }

        [HttpPost("CadastrarPedido")]
        public async Task<IActionResult> CadastrarPedido(Pedido pedido)
        {
            if (pedido == null)
            {
                return NotFound();
            }

            await _doceriaContext.AddAsync(pedido);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("ListarPedidos")]
        public async Task<IActionResult> ListarPedidos()
        {
            var pedidos = await _doceriaContext.Pedidos.ToListAsync();

            if (pedidos == null)
            {
                return NotFound();
            }

            return Ok(pedidos);
        }

        [HttpGet("BuscarPedido/{id}")]
        public async Task<IActionResult> BuscarPedidoPorId(int id)
        {
            var pedido = await _doceriaContext.Pedidos.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        [HttpPut("AtualizarPedido/{id}")]
        public async Task<IActionResult> AtualizarPedido(int id, Pedido pedido)
        {
            var pedidoBanco = await _doceriaContext.Pedidos.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            pedidoBanco.TotalPedido = pedido.TotalPedido;
            pedidoBanco.Status = pedido.Status;

            _doceriaContext.Update(pedido);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("Deletar/{id}")]
        public async Task<IActionResult> ExcluirPedido(int id)
        {
            var pedidoBanco = await _doceriaContext.Pedidos.FindAsync(id);

            if (pedidoBanco == null)
            {
                return NotFound();
            }

            _doceriaContext.Pedidos.Remove(pedidoBanco);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }
    }
}
