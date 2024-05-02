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
        public async Task<IActionResult> CadastrarHistoricoIngrediente(int id)
        {
            var ingrediente = await _doceriaContext.Ingredientes.FindAsync(id);

            var historico = new Historico_Ingrediente();

            if (ingrediente == null)
            {
                return NotFound();
            }

            historico.Ingrediente = ingrediente;
            historico.Preco = ingrediente.Preco;
            historico.Quantidade = ingrediente.Quantidade;
            historico.Unidade = ingrediente.Unidade;
            historico.Data = ingrediente.Data;

            await _doceriaContext.AddAsync(historico);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("ListarHistorico/{id}")]
        public IActionResult ListarHistoricoIngrediente(int id)
        {
            var historico = _doceriaContext.Historico_Ingredientes.Where(x => x.Ingrediente.Id == id);

            if (historico == null)
            {
                return NotFound();
            }

            return Ok(historico);
        }
    }
}
