using API_Doceria.Context;
using API_Doceria.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Doceria.Controllers
{
    [ApiController]
    [Route("api/v1/ingrediente/")]
    public class IngredienteController : ControllerBase
    {
        private readonly DoceriaContext _doceriaContext;

        public IngredienteController(DoceriaContext doceriaContext)
        {
            _doceriaContext = doceriaContext;
        }

        [HttpPost("")]
        public async Task<IActionResult> CadastrarIngrediente(Ingrediente ingrediente)
        {
            if (ingrediente == null)
            {
                return BadRequest();
            }

            await _doceriaContext.AddAsync(ingrediente);
            await _doceriaContext.SaveChangesAsync();

            return Created();
        }

        [HttpGet("")]
        public async Task<IActionResult> ListarIngredientes()
        {
            var ingredientes = await _doceriaContext.Ingredientes.ToListAsync();

            return Ok(ingredientes);
        }

        [HttpPut("")]
        public async Task<IActionResult> AtualizarIngrediente(Ingrediente ingrediente)
        {
            var ingredienteBanco = await _doceriaContext.Ingredientes.FindAsync(ingrediente.Id);

            if (ingredienteBanco == null)
            {
                return NotFound();
            }

            await CadastrarHistorico(ingredienteBanco);

            ingredienteBanco.Quantidade = ingrediente.Quantidade;
            ingredienteBanco.Preco = ingrediente.Preco;
            ingredienteBanco.Unidade = ingrediente.Unidade;
            ingredienteBanco.Data = ingrediente.Data;

            _doceriaContext.Update(ingredienteBanco);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
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

        private async Task<IActionResult> CadastrarHistorico(Ingrediente ingrediente)
        {
            var historico = new Historico_Ingrediente();

            historico.Ingrediente = ingrediente;
            historico.Preco = ingrediente.Preco;
            historico.Quantidade = ingrediente.Quantidade;
            historico.Unidade = ingrediente.Unidade;
            historico.Data = ingrediente.Data;

            await _doceriaContext.Historico_Ingredientes.AddAsync(historico);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }
    }
}
