using API_Doceria.Context;
using API_Doceria.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Doceria.Controllers
{
    [ApiController]
    [Route("api/va/receita-ingrediente/")]
    public class Receita_IngredienteController : ControllerBase
    {
        private readonly DoceriaContext _doceriaContext;

        public Receita_IngredienteController(DoceriaContext doceriaContext)
        {
            _doceriaContext = doceriaContext;
        }

        [HttpGet("")]
        public IActionResult ListarReceitaIngrediente(Receita receita)
        {
            var receitaIngredientes = _doceriaContext.Receita_Ingrediente.Where(x => x.Receita.Id == receita.Id);

            if (receitaIngredientes == null)
            {
                return NotFound();
            }

            return Ok(receitaIngredientes);
        }
    }
}
