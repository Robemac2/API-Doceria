using API_Doceria.Context;
using API_Doceria.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Doceria.Controllers
{
    [ApiController]
    [Route("api/v1/usuario/")]
    public class UsuarioController : ControllerBase
    {
        private readonly DoceriaContext _doceriaContext;

        public UsuarioController(DoceriaContext doceriaContext)
        {
            _doceriaContext = doceriaContext;
        }

        [HttpPost("")]
        public async Task<IActionResult> CadastrarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                return NotFound();
            }

            await _doceriaContext.AddAsync(usuario);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarUsuarios()
        {
            var usuarios = await _doceriaContext.Usuarios.ToListAsync();

            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        [HttpGet("validar")]
        public IActionResult ValidarUsuario(string nome, string senha)
        {
            if (nome == null || senha == null)
            {
                return NotFound();
            }

            var usuarioBanco = _doceriaContext.Usuarios.Where(x => x.Nome == nome && x.Senha == senha);

            if (usuarioBanco == null)
            {
                return NotFound();
            }

            return Ok(usuarioBanco);
        }

        [HttpPut("")]
        public async Task<IActionResult> AtualizarUsuario(Usuario usuario)
        {
            var usuarioBanco = await _doceriaContext.Usuarios.FindAsync(usuario.Id);

            if (usuarioBanco == null)
            {
                return NotFound();
            }

            usuarioBanco.Senha = usuario.Senha;
            usuarioBanco.TipoUsuario = usuario.TipoUsuario;

            _doceriaContext.Update(usuarioBanco);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirUsuario(int id)
        {
            var usuarioBanco = await _doceriaContext.Usuarios.FindAsync(id);

            if (usuarioBanco == null)
            {
                return NotFound();
            }

            _doceriaContext.Usuarios.Remove(usuarioBanco);
            await _doceriaContext.SaveChangesAsync();

            return Ok();
        }
    }
}
