using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsuarioAPI.Data;
using UsuarioAPI.Models;

namespace UsuarioAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        private async Task<bool> UsuarioExistente(string nome)
        {
            if (await _context.TB_USUARIOS.AnyAsync(x => x.Nome.ToLower() == nome.ToLower()))
            {
                return true;
            }
            return false;
        }

        [HttpGet("{rm}")]
        public async Task<IActionResult> GetSingle(int rm)
        {
            try
            {
                Usuario u = await _context.TB_USUARIOS
                    .FirstOrDefaultAsync(uBusca => uBusca.Rm == rm);
                return Ok(u);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Usuario> listaU = await _context.TB_USUARIOS.ToListAsync();
                return Ok(listaU);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario usuario)
        {
            try
            {
                if (await UsuarioExistente(usuario.Nome))
                {
                    throw new System.Exception("Nome de ususário já existe");
                }

                await _context.TB_USUARIOS.AddAsync(usuario);
                await _context.SaveChangesAsync();

                return Ok(usuario.Rm);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut("AlterarSenha")]
        public async Task<IActionResult> AlterarSenha(Usuario user)
        {
            try{
                Usuario? usuario = await _context.TB_USUARIOS
                    .FirstOrDefaultAsync(x => x.Nome.ToLower().Equals(user.Nome.ToLower()));

                if(usuario == null){
                    throw new System.Exception("Usuário não encontrado.");
                }else{
                    usuario.Senha = usuario.Senha;//errado

                    _context.TB_USUARIOS.Update(usuario);
                    await _context.SaveChangesAsync();
                    return Ok("Senha alterada!");
                }
                
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }
    }
}