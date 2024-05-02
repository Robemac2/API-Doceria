using API_Doceria.Context;
using API_Doceria.Entities;
using API_Doceria.Enum;
using Microsoft.AspNetCore.Mvc;

namespace API_Doceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Pedido_ReceitaController : ControllerBase
    {
        private readonly DoceriaContext _doceriaContext;

        public Pedido_ReceitaController(DoceriaContext doceriaContext)
        {
            _doceriaContext = doceriaContext;
        }

        [HttpPost("CadastrarPedidoReceita/{idPedido}/{idReceita}/{pedidoReceitaCadastro}")]
        public async Task<IActionResult> CadastrarPedidoReceita(int idPedido, int idReceita, Pedido_Receita pedidoReceitaCadastro)
        {
            var pedido = await _doceriaContext.Pedidos.FindAsync(idPedido);
            var receita = await _doceriaContext.Receitas.FindAsync(idReceita);

            if (pedido == null || receita == null)
            {
                return NotFound();
            }

            var pedidoReceita = new Pedido_Receita();

            pedidoReceita.Pedido = pedido;
            pedidoReceita.Receita = receita;
            pedidoReceita.Quantidade = pedidoReceitaCadastro.Quantidade;
            pedidoReceita.Total = pedidoReceitaCadastro.Total;

            await _doceriaContext.AddAsync(pedidoReceita);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("ListarPedidoReceita/{idPedido}")]
        public IActionResult ListarPedidoReceita(int idPedido)
        {
            var pedidoReceitas = _doceriaContext.Pedido_Receitas.Where(x => x.Pedido.Id == idPedido);

            if (pedidoReceitas == null)
            {
                return NotFound();
            }

            return Ok(pedidoReceitas);
        }

        [HttpGet("ListarPedidos/{status}")]
        public IActionResult ListarPedidoPorStatus(StatusPedido status)
        {
            var pedidos = _doceriaContext.Pedido_Receitas.Where(x => x.Pedido.Status == status);

            if (pedidos == null)
            {
                return NotFound();
            }

            return Ok(pedidos);
        }

        [HttpDelete("DeletarPedidoReceita/{idPedido}")]
        public async Task<IActionResult> DeletarPedidoReceita(int idPedido)
        {
            var pedidos = _doceriaContext.Pedido_Receitas.Where(x => x.Pedido.Id == idPedido);

            if (pedidos == null)
            {
                return NotFound();
            }

            _doceriaContext.Remove(pedidos);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }
    }
}
