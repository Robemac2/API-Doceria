using API_Doceria.Context;
using API_Doceria.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult CadastrarReceita(Receita receita)
        {
            if (receita == null)
            {
                return NotFound();
            }

            _doceriaContext.Add(receita);
            _doceriaContext.SaveChanges();

            return Ok();
        }

        [HttpGet("ListarReceitas")]
        public IActionResult ListarReceitas()
        {
            var receitas = _doceriaContext.Receitas;

            if (receitas == null)
            {
                return NotFound();
            }

            return Ok(receitas);
        }

        [HttpPut("AtualizarReceita/{id}")]
        public IActionResult AtualizarReceita(int id, Receita receita)
        {
            var receitaBanco = _doceriaContext.Receitas.Find(id);

            if (receitaBanco == null)
            {
                return NotFound();
            }

            receitaBanco.PrecoUnitario = receita.PrecoUnitario;
            receitaBanco.Rendimento = receita.Rendimento;
            receitaBanco.Preco = receita.Preco;
            receitaBanco.TempoDePreparo = receita.TempoDePreparo;

            _doceriaContext.Update(receitaBanco);
            _doceriaContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult ExcluirReceita(int id)
        {
            var receitaBanco = _doceriaContext.Receitas.Find(id);

            if (receitaBanco == null)
            {
                return NotFound();
            }

            _doceriaContext.Receitas.Remove(receitaBanco);
            _doceriaContext.SaveChanges();

            return Ok();
        }
    }
}
