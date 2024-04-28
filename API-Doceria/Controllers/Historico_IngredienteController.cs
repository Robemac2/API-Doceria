using API_Doceria.Context;
using API_Doceria.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Doceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Historico_IngredienteController : ControllerBase
    {
        public readonly DoceriaContext _doceriaContext;

        public Historico_IngredienteController(DoceriaContext doceriaContext)
        {
            _doceriaContext = doceriaContext;
        }

        [HttpPost("CadastrarHistorico/{id}")]
        public IActionResult CadastrarHistoricoIngrediente(int id)
        {
            if (_doceriaContext.Ingredientes.Find(id) == null)
            {
                return BadRequest(new { Erro = "O ingrediente não pode ser nulo" });
            }

            var ingrediente = _doceriaContext.Ingredientes.Find(id);

            var historico = new Historico_Ingrediente();

            historico.Ingrediente = ingrediente;
            historico.Preco = ingrediente.Preco;
            historico.Quantidade = ingrediente.Quantidade;
            historico.Unidade = ingrediente.Unidade;
            historico.Data = ingrediente.Data;

            _doceriaContext.Add(historico);
            _doceriaContext.SaveChanges();

            return Ok();
        }

        [HttpGet("ListarHistorico/{id}")]
        public IActionResult ListarHistoricoIngrediente(int id)
        {
            var historico = _doceriaContext.Historico_Ingredientes.All(x => x.Ingrediente.Id == id);

            return Ok(historico);
        }
    }
}
