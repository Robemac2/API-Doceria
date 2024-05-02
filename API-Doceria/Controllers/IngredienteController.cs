using API_Doceria.Context;
using API_Doceria.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> CadastrarIngrediente(Ingrediente ingrediente)
        {
            if (ingrediente == null)
            {
                return NotFound();
            }

            await _doceriaContext.AddAsync(ingrediente);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("ListarIngredientes")]
        public async Task<IActionResult> ListarIngredientes()
        {
            var ingredientes = await _doceriaContext.Ingredientes.ToListAsync();

            if (ingredientes == null)
            {
                return NotFound();
            }

            return Ok(ingredientes);
        }

        [HttpPut("AtualizarIngrediente/{id}")]
        public async Task<IActionResult> AtualizarIngrediente(int id, Ingrediente ingrediente)
        {
            var ingredienteBanco = await _doceriaContext.Ingredientes.FindAsync(id);

            if (ingredienteBanco == null)
            {
                return NotFound();
            }

            ingredienteBanco.Quantidade = ingrediente.Quantidade;
            ingredienteBanco.Preco = ingrediente.Preco;
            ingredienteBanco.Unidade = ingrediente.Unidade;
            ingredienteBanco.Data = ingrediente.Data;

            _doceriaContext.Update(ingredienteBanco);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("Deletar/{id}")]
        public async Task<IActionResult> ExcluirIngrediente(int id)
        {
            var ingredienteBanco = await _doceriaContext.Ingredientes.FindAsync(id);

            if (ingredienteBanco == null)
            {
                return NotFound();
            }

            _doceriaContext.Ingredientes.Remove(ingredienteBanco);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }
    }
}
