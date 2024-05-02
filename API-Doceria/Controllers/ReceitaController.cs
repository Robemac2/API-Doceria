using API_Doceria.Context;
using API_Doceria.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Doceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceitaController : ControllerBase
    {
        private readonly DoceriaContext _doceriaContext;

        public ReceitaController(DoceriaContext doceriaContext)
        {
            _doceriaContext = doceriaContext;
        }

        [HttpPost("CadastrarReceita")]
        public async Task<IActionResult> CadastrarReceita(Receita receita)
        {
            if (receita == null)
            {
                return NotFound();
            }

            await _doceriaContext.AddAsync(receita);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("ListarReceitas")]
        public async Task<IActionResult> ListarReceitas()
        {
            var receitas = await _doceriaContext.Receitas.ToListAsync();

            if (receitas == null)
            {
                return NotFound();
            }

            return Ok(receitas);
        }

        [HttpPut("AtualizarReceita/{id}")]
        public async Task<IActionResult> AtualizarReceita(int id, Receita receita)
        {
            var receitaBanco = await _doceriaContext.Receitas.FindAsync(id);

            if (receitaBanco == null)
            {
                return NotFound();
            }

            receitaBanco.PrecoUnitario = receita.PrecoUnitario;
            receitaBanco.Rendimento = receita.Rendimento;
            receitaBanco.Preco = receita.Preco;
            receitaBanco.TempoDePreparo = receita.TempoDePreparo;

            _doceriaContext.Update(receitaBanco);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("Deletar/{id}")]
        public async Task<IActionResult> ExcluirReceita(int id)
        {
            var receitaBanco = await _doceriaContext.Receitas.FindAsync(id);

            if (receitaBanco == null)
            {
                return NotFound();
            }

            _doceriaContext.Receitas.Remove(receitaBanco);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }
    }
}
