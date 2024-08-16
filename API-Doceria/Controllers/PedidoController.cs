using API_Doceria.Context;
using API_Doceria.Entities;
using API_Doceria.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Doceria.Controllers
{
    [ApiController]
    [Route("api/v1/pedido/")]
    public class PedidoController : ControllerBase
    {
        private readonly DoceriaContext _doceriaContext;

        public PedidoController(DoceriaContext doceriaContext)
        {
            _doceriaContext = doceriaContext;
        }

        [HttpPost("")]
        public async Task<IActionResult> CadastrarPedido(Pedido pedido)
        {
            if (pedido.Cliente == string.Empty)
            {
                return BadRequest();
            }

            await _doceriaContext.AddAsync(pedido);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> ListarPedidos()
        {
            var pedidos = await _doceriaContext.Pedidos.ToListAsync();

            if (pedidos.Count() == 0)
            {
                return NotFound();
            }

            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPedidoPorId(int id)
        {
            var pedido = await _doceriaContext.Pedidos.FindAsync(id);

            if (pedido == null)
            {
                return BadRequest();
            }

            return Ok(pedido);
        }

        [HttpGet("buscar/{status}")]
        public IActionResult ListarPedidoPorStatus(string status)
        {
            var pedidos = _doceriaContext.Pedidos.Where(x => x.Status == status);

            if (pedidos.Count() == 0)
            {
                return BadRequest();
            }

            return Ok(pedidos);
        }

        [HttpPut("")]
        public async Task<IActionResult> AtualizarPedido(Pedido pedido)
        {
            var pedidoBanco = await _doceriaContext.Pedidos.FindAsync(pedido.Id);

            if (pedidoBanco == null)
            {
                return NotFound();
            }

            pedidoBanco.TotalPedido = pedido.TotalPedido;
            pedidoBanco.Status = pedido.Status;

            _doceriaContext.Update(pedidoBanco);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirPedido(int id)
        {
            var pedidoBanco = await _doceriaContext.Pedidos.FindAsync(id);

            if (pedidoBanco == null)
            {
                return BadRequest();
            }

            _doceriaContext.Pedidos.Remove(pedidoBanco);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }
    }
}
