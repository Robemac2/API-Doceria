using API_Doceria.Context;
using API_Doceria.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Doceria.Controllers
{
    [ApiController]
    [Route("api/v1/receita/")]
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
            if (receita.Nome == string.Empty)
            {
                return BadRequest();
            }

            await _doceriaContext.AddAsync(receita);
            await _doceriaContext.SaveChangesAsync();

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

            receitaBanco.TempoDePreparo = receita.TempoDePreparo;
            receitaBanco.Preco = receita.Preco;
            receitaBanco.Rendimento = receita.Rendimento;
            receitaBanco.PrecoUnitario = receita.PrecoUnitario;

            _doceriaContext.Update(receitaBanco);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirReceita(int id)
        {
            var receitaBanco = await _doceriaContext.Receitas.FindAsync(id);

            if (receitaBanco.Nome == string.Empty)
            {
                return NotFound();
            }

            _doceriaContext.Receitas.Remove(receitaBanco);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }
    }
}
