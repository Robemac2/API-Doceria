using API_Doceria.Context;
using API_Doceria.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Doceria.Controllers
{
    [ApiController]
    [Route("api/v1/pedido-receita/")]
    public class Pedido_ReceitaController : ControllerBase
    {
        private readonly DoceriaContext _doceriaContext;

        public Pedido_ReceitaController(DoceriaContext doceriaContext)
        {
            _doceriaContext = doceriaContext;
        }

        [HttpPost("")]
        public async Task<IActionResult> CadastrarPedidoReceita(List<Pedido_Receita> receitas)
        {
            if (receitas.Count == 0)
            {
                return BadRequest();
            }

            await _doceriaContext.AddRangeAsync(receitas);
            await _doceriaContext.SaveChangesAsync();

            return Created();
        }

        [HttpGet("")]
        public IActionResult ListarPedidoReceita(Pedido pedido)
        {
            var pedidoReceitas = _doceriaContext.Pedido_Receitas.Where(x => x.PedidoId == pedido.Id);

            if (pedidoReceitas.Count() == 0)
            {
                return NotFound();
            }

            return Ok(pedidoReceitas);
        }

        [HttpDelete("{idPedido}")]
        public async Task<IActionResult> DeletarPedidoReceita(int idPedido)
        {
            var pedidos = _doceriaContext.Pedido_Receitas.Where(x => x.PedidoId == idPedido);

            if (pedidos.Count() == 0)
            {
                return BadRequest();
            }

            _doceriaContext.Pedido_Receitas.RemoveRange(pedidos);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }
    }
}
