using API_Doceria.Context;
using API_Doceria.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Doceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredienteController : ControllerBase
    {
        private readonly DoceriaContext _doceriaContext;

        public IngredienteController(DoceriaContext doceriaContext)
        {
            _doceriaContext = doceriaContext;
        }

        [HttpPost("CadastrarIngrediente")]
        public IActionResult CadastrarIngrediente(Ingrediente ingrediente)
        {
            if (ingrediente == null)
            {
                return BadRequest(new { Erro = "O ingrediente não pode ser nulo" });
            }

            _doceriaContext.Add(ingrediente);
            _doceriaContext.SaveChanges();

            return Ok();
        }

        [HttpGet("ListarIngredientes")]
        public IActionResult ListarIngredientes()
        {
            var ingredientes = _doceriaContext.Ingredientes;

            if (ingredientes == null)
            {
                return NotFound();
            }

            return Ok(ingredientes);
        }

        [HttpPut("AtualizarIngrediente/{id}")]
        public IActionResult AtualizarIngrediente(int id, Ingrediente ingrediente)
        {
            var ingredienteBanco = _doceriaContext.Ingredientes.Find(id);

            if (ingredienteBanco == null)
            {
                return NotFound();
            }

            ingredienteBanco.Quantidade = ingrediente.Quantidade;
            ingredienteBanco.Preco = ingrediente.Preco;
            ingredienteBanco.Unidade = ingrediente.Unidade;
            ingredienteBanco.Data = ingrediente.Data;

            _doceriaContext.Update(ingredienteBanco);
            _doceriaContext.SaveChanges();

            return Ok(ingredienteBanco);
        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult ExcluirIngrediente(int id)
        {
            var ingredienteBanco = _doceriaContext.Ingredientes.Find(id);

            if (ingredienteBanco == null)
            {
                return NotFound();
            }

            _doceriaContext.Ingredientes.Remove(ingredienteBanco);
            _doceriaContext.SaveChanges();

            return NoContent();
        }
    }
}
