using API_Doceria.Context;
using API_Doceria.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Doceria.Controllers
{
    [ApiController]
    [Route("api/v1/historico-ingrediente/")]
    public class Historico_IngredienteController : ControllerBase
    {
        public readonly DoceriaContext _doceriaContext;

        public Historico_IngredienteController(DoceriaContext doceriaContext)
        {
            _doceriaContext = doceriaContext;
        }

        [HttpGet("")]
        public IActionResult ListarHistoricoIngrediente(Ingrediente ingrediente)
        {
            var historico = _doceriaContext.Historico_Ingredientes.Where(x => x.Ingrediente.Id == ingrediente.Id);

            return Ok(historico);
        }
    }
}
