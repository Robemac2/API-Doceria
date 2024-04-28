using API_Doceria.Context;
using API_Doceria.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Doceria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly DoceriaContext _doceriaContext;

        public UsuarioController(DoceriaContext doceriaContext)
        {
            _doceriaContext = doceriaContext;
        }

        [HttpPost("CadastrarUsuario")]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest(new { Erro = "O usuário não pode ser nulo" });
            }

            _doceriaContext.Add(usuario);
            _doceriaContext.SaveChanges();

            return Ok();
        }

        [HttpGet("ListarUsuarios")]
        public IActionResult ListarUsuarios()
        {
            var usuarios = _doceriaContext.Usuarios;

            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        [HttpGet("ValidarUsuario/{nome}/{senha}")]
        public IActionResult ValidarUsuario(string nome, string senha)
        {
            if (nome == null || senha == null)
            {
                return BadRequest(new { Erro = "O usuário e senha não podem ser nulos" });
            }

            var usuarioBanco = _doceriaContext.Usuarios.Where(x => x.Nome == nome && x.Senha == senha);

            if (usuarioBanco == null)
            {
                return BadRequest(new { Erro = "Usuário ou senha incorretos" });
            }

            return Ok(usuarioBanco);
        }

        [HttpPut("AtualizarUsuario/{id}")]
        public IActionResult AtualizarUsuario(int id, Usuario usuario)
        {
            var usuarioBanco = _doceriaContext.Usuarios.Find(id);

            if (usuarioBanco == null)
            {
                return NotFound();
            }

            usuarioBanco.Senha = usuario.Senha;
            usuarioBanco.TipoUsuario = usuario.TipoUsuario;

            _doceriaContext.Update(usuarioBanco);
            _doceriaContext.SaveChanges();

            return Ok(usuarioBanco);
        }

        [HttpDelete("Deletar/{id}")]
        public IActionResult ExcluirUsuario(int id)
        {
            var usuarioBanco = _doceriaContext.Usuarios.Find(id);

            if (usuarioBanco == null)
            {
                return NotFound();
            }

            _doceriaContext.Usuarios.Remove(usuarioBanco);
            _doceriaContext.SaveChanges();

            return NoContent();
        }
    }
}
