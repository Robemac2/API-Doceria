using API_Doceria.Context;
using API_Doceria.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Doceria.Controllers
{
    [ApiController]
    [Route("api/v1/receita-ingrediente/")]
    public class Receita_IngredienteController : ControllerBase
    {
        private readonly DoceriaContext _doceriaContext;

        public Receita_IngredienteController( DoceriaContext doceriaContext )
        {
            _doceriaContext = doceriaContext;
        }

        [HttpPost("")]
        public async Task<IActionResult> CadastrarIngredientesReceita( List<Receita_Ingrediente> ingredientes )
        {
            if ( ingredientes.Count == 0 )
            {
                return BadRequest();
            }

            foreach ( Receita_Ingrediente ingrediente in ingredientes )
            {
                await _doceriaContext.AddAsync(ingrediente);
                await _doceriaContext.SaveChangesAsync();
            }

            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult ListarReceitaIngrediente( int id )
        {
            var receitaIngredientes = _doceriaContext.Receita_Ingrediente.Where(x => x.ReceitaId == id);

            if ( receitaIngredientes.Count() == 0 )
            {
                return NotFound();
            }

            return Ok(receitaIngredientes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirIngredientesReceita( int id )
        {
            var ingredientes = _doceriaContext.Receita_Ingrediente.Where(x => x.ReceitaId == id);

            if ( ingredientes.Count() == 0 )
            {
                return BadRequest();
            }

            _doceriaContext.RemoveRange(ingredientes);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }
    }
}
