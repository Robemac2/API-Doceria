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
        public IActionResult CadastrarReceitaIngrediente(int idReceita, int idIngrediente)
        {
            var ingrediente = _doceriaContext.Ingredientes.Find(idIngrediente);
            var receita = _doceriaContext.Receitas.Find(idReceita);

            if (receita == null || ingrediente == null)
            {
                return BadRequest(new { Erro = "A receita e o ingrediente não podem ser nulos" });
            }

            var receitaIngrediente = new Receita_Ingrediente();

            receitaIngrediente.Receita = receita;
            receitaIngrediente.Ingrediente = ingrediente;

            _doceriaContext.Add(receitaIngrediente);
            _doceriaContext.SaveChanges();

            return Ok();
        }

        [HttpGet("ListarReceitaIngrediente/{idReceita}")]
        public IActionResult ListarReceitaIngrediente(int idReceita)
        {
            var receitaIngredientes = _doceriaContext.Receita_Ingrediente.Where(x => x.Receita.Id == idReceita);

            if (receitaIngredientes == null)
            {
                return BadRequest(new { Erro = "A receita não pode ser nula" });
            }

            return Ok(receitaIngredientes);
        }

        [HttpDelete("DeletarReceitaIngrediente/{idReceita}")]
        public IActionResult DeletarReceitaIngrediente(int idReceita)
        {
            var deletar = _doceriaContext.Receita_Ingrediente.Where(x => x.Receita.Id == idReceita);

            _doceriaContext.Receita_Ingrediente.RemoveRange(deletar);

            return NotFound();
        }
    }
}
