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
        public IActionResult CadastrarPedidoReceita(int idPedido, int idReceita, Pedido_Receita pedidoReceitaCadastro)
        {
            var pedido = _doceriaContext.Pedidos.Find(idPedido);
            var receita = _doceriaContext.Receitas.Find(idReceita);

            if (pedido == null || receita == null)
            {
                return BadRequest(new { Erro = "A receita e o pedido não podem ser nulos" });
            }

            var pedidoReceita = new Pedido_Receita();

            pedidoReceita.Pedido = pedido;
            pedidoReceita.Receita = receita;
            pedidoReceita.Quantidade = pedidoReceitaCadastro.Quantidade;
            pedidoReceita.Total = pedidoReceitaCadastro.Total;

            _doceriaContext.Add(pedidoReceita);
            _doceriaContext.SaveChanges();

            return Ok(pedidoReceita);
        }

        [HttpGet("ListarPedidoReceita/{idPedido}")]
        public IActionResult ListarPedidoReceita(int idPedido)
        {
            var pedidoReceitas = _doceriaContext.Pedido_Receitas.Where(x => x.Pedido.Id == idPedido);

            if (pedidoReceitas == null)
            {
                return BadRequest(new { Erro = "O pedido não pode ser nulo" });
            }

            return Ok(pedidoReceitas);
        }

        [HttpGet("ListarPedidos/{status}")]
        public  IActionResult ListarPedidoPorStatus(StatusPedido status)
        {
            var pedidos = _doceriaContext.Pedido_Receitas.Where(x => x.Pedido.Status == status);

            if (pedidos == null)
            {
                return BadRequest(new { Erro = "O pedido não pode ser nulo" });
            }

            return Ok(pedidos);
        }

        [HttpDelete("DeletarPedidoReceita/{idPedido}")]
        public IActionResult DeletarPedidoReceita(int idPedido)
        {
            var pedidos = _doceriaContext.Pedido_Receitas.Where(x => x.Pedido.Id == idPedido);

            if (pedidos == null)
            {
                return BadRequest(new { Erro = "O pedido não pode ser nulo" });
            }

            _doceriaContext.Remove(pedidos);
            _doceriaContext.SaveChanges();

            return NotFound();
        }
    }
}
