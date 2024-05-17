using API_Doceria.Context;
using Microsoft.AspNetCore.Mvc;

namespace API_Doceria.Controllers
{
    [ApiController]
    [Route("api/v1/historico-ingrediente/")]
    public class Historico_IngredienteController : ControllerBase
    {
        public readonly DoceriaContext _doceriaContext;

        public Historico_IngredienteController( DoceriaContext doceriaContext )
        {
            _doceriaContext = doceriaContext;
        }

        [HttpGet("{id}")]
        public IActionResult ListarHistoricoIngrediente( int id )
        {
            var historico = _doceriaContext.Historico_Ingredientes.Where(x => x.Ingrediente.Id == id);

            return Ok(historico);
        }
    }
}
