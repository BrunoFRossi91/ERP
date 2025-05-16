using AutoMapper;
using ERP.Data;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        private GDRContext _context;
        private IMapper _mapper;

        public LoginController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult VerificarUsuarioExistente([FromBody] UsuarioLoginModel model)
        {
            // Verificar se o usuário com o email fornecido existe no banco de dados
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == model.Email);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }
            else
            {
                // Verificar se a senha fornecida corresponde à senha armazenada no banco de dados
                if (usuario.Senha == model.Senha)
                {
                    return Ok("Credenciais válidas");
                }
                else
                {
                    return Unauthorized("Senha incorreta");
                }
            }
        }
    }

    public class UsuarioLoginModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }

}
