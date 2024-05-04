using API_Doceria.Context;
using API_Doceria.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Doceria.Controllers
{
    [ApiController]
    [Route("api/v1/receitas/")]
    public class ReceitaController : ControllerBase
    {
        private readonly DoceriaContext _doceriaContext;

        public ReceitaController(DoceriaContext doceriaContext)
        {
            _doceriaContext = doceriaContext;
        }

        [HttpPost("")]
        public async Task<IActionResult> CadastrarReceita(Receita receita)
        {
            if (receita.Nome == string.Empty || receita.Ingredientes.Count() == 0)
            {
                return BadRequest();
            }

            await _doceriaContext.AddAsync(receita);
            await _doceriaContext.SaveChangesAsync();

            var receitaSalva = await _doceriaContext.Receitas.Where(x => x.Nome == receita.Nome).FirstAsync();

            await CadastrarIngredientesReceita(receitaSalva);

            return Created();
        }

        [HttpGet("")]
        public async Task<IActionResult> ListarReceitas()
        {
            var receitas = await _doceriaContext.Receitas.ToListAsync();

            return Ok(receitas);
        }

        [HttpPut("")]
        public async Task<IActionResult> AtualizarReceita(Receita receita)
        {
            var receitaBanco = await _doceriaContext.Receitas.FindAsync(receita.Id);

            if (receitaBanco == null)
            {
                return NotFound();
            }

            receitaBanco.Ingredientes = receita.Ingredientes;
            receitaBanco.TempoDePreparo = receita.TempoDePreparo;
            receitaBanco.Preco = receita.Preco;
            receitaBanco.Rendimento = receita.Rendimento;
            receitaBanco.PrecoUnitario = receita.PrecoUnitario;

            _doceriaContext.Update(receitaBanco);
            await _doceriaContext.SaveChangesAsync();

            await ExcluirIngredientesReceita(receita);
            await CadastrarIngredientesReceita(receitaBanco);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirReceita(int id)
        {
            var receitaBanco = await _doceriaContext.Receitas.FindAsync(id);

            if (receitaBanco == null)
            {
                return NotFound();
            }

            _doceriaContext.Receitas.Remove(receitaBanco);
            await _doceriaContext.SaveChangesAsync();

            await ExcluirIngredientesReceita(receitaBanco);

            return Ok();
        }

        private async Task<IActionResult> CadastrarIngredientesReceita(Receita receita)
        {
            foreach (var ingrediente in receita.Ingredientes)
            {
                var ingredienteBanco = new Receita_Ingrediente();

                ingredienteBanco.Receita = receita;
                ingredienteBanco.Ingrediente = ingrediente.Ingrediente;
                ingredienteBanco.Quantidade = ingrediente.Quantidade;
                ingredienteBanco.Unidade = ingrediente.Unidade;
                ingredienteBanco.Preco = ingrediente.Preco;

                await _doceriaContext.AddAsync(ingredienteBanco);
                await _doceriaContext.SaveChangesAsync();
            }

            return Created();
        }

        private async Task<IActionResult> ExcluirIngredientesReceita(Receita receita)
        {
            var ingredientes = _doceriaContext.Receita_Ingrediente.Where(x => x.Receita.Id == receita.Id);

            _doceriaContext.Receita_Ingrediente.RemoveRange(ingredientes);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }
    }
}
