using API_Doceria.Context;
using API_Doceria.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult CadastrarPedido(Pedido pedido)
        {
            if (pedido == null)
            {
                return BadRequest(new { Erro = "O pedido não pode ser nulo" });
            }

            _doceriaContext.Add(pedido);
            _doceriaContext.SaveChanges();

            return Ok();
        }

        [HttpGet("ListarPedidos")]
        public IActionResult ListarPedidos()
        {
            var pedidos = _doceriaContext.Pedidos;

            if (pedidos == null)
            {
                return NotFound();
            }

            return Ok(pedidos);
        }

        [HttpGet("BuscarPedido/{id}")]
        public IActionResult BuscarPedidoPorId(int id)
        {
            var pedido = _doceriaContext.Pedidos.Find(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        [HttpPut("AtualizarPedido/{id}")]
        public IActionResult AtualizarPedido(int id, Pedido pedido)
        {
            var pedidoBanco = _doceriaContext.Pedidos.Find(id);

            if (pedido == null)
            {
                return NotFound();
            }

            pedidoBanco.TotalPedido = pedido.TotalPedido;
            pedidoBanco.Status = pedido.Status;

            _doceriaContext.Update(pedido);
            _doceriaContext.SaveChanges();

            return Ok(pedido);
        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult ExcluirPedido(int id)
        {
            var pedidoBanco = _doceriaContext.Pedidos.Find(id);

            if (pedidoBanco == null)
            {
                return NotFound();
            }

            _doceriaContext.Pedidos.Remove(pedidoBanco);
            _doceriaContext.SaveChanges();

            return NoContent();
        }
    }
}
