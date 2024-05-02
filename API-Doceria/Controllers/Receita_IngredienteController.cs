using API_Doceria.Context;
using API_Doceria.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Doceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Receita_IngredienteController : ControllerBase
    {
        private readonly DoceriaContext _doceriaContext;

        public Receita_IngredienteController(DoceriaContext doceriaContext)
        {
            _doceriaContext = doceriaContext;
        }

        [HttpPost("CadastrarReceitaIngrediente/{idReceita}/{idIngrediente}")]
        public async Task<IActionResult> CadastrarReceitaIngrediente(int idReceita, int idIngrediente)
        {
            var ingrediente = await _doceriaContext.Ingredientes.FindAsync(idIngrediente);
            var receita = await _doceriaContext.Receitas.FindAsync(idReceita);

            if (receita == null || ingrediente == null)
            {
                return NotFound();
            }

            var receitaIngrediente = new Receita_Ingrediente();

            receitaIngrediente.Receita = receita;
            receitaIngrediente.Ingrediente = ingrediente;

            await _doceriaContext.AddAsync(receitaIngrediente);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("ListarReceitaIngrediente/{idReceita}")]
        public IActionResult ListarReceitaIngrediente(int idReceita)
        {
            var receitaIngredientes = _doceriaContext.Receita_Ingrediente.Where(x => x.Receita.Id == idReceita);

            if (receitaIngredientes == null)
            {
                return NotFound();
            }

            return Ok(receitaIngredientes);
        }

        [HttpDelete("DeletarReceitaIngrediente/{idReceita}")]
        public IActionResult DeletarReceitaIngrediente(int idReceita)
        {
            var deletar = _doceriaContext.Receita_Ingrediente.Where(x => x.Receita.Id == idReceita);

            _doceriaContext.Receita_Ingrediente.RemoveRange(deletar);

            return Ok();
        }
    }
}
