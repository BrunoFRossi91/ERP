using AutoMapper;
using ERP.Data;
using ERP.Dto;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsuariosController : ControllerBase
    {
        private GDRContext _context;
        private IMapper _mapper;

        public UsuariosController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public void AdicionarUsuario([FromBody] UsuariosDto usuario)
        {
            EntityUser EntityUser = _mapper.Map<EntityUser>(usuario);
            EntityUser.DataCriacao = DateTime.Now;
            _context.Usuarios.Add(EntityUser);
            _context.SaveChanges();
        }

        [HttpGet]
        public IActionResult LerUsuarioPorId(int id)
        {
            var usuarioFiltrada = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);
            if (usuarioFiltrada == null)
                return NotFound();
            return Ok(usuarioFiltrada);
        }

        [HttpGet]
        public List<UsuariosDto> LerUsuario()
        {
            List<EntityUser> usuarios = _context.Usuarios.Include(e => e.Empresa).ToList();
            List<UsuariosDto> usuariosDto = new List<UsuariosDto>();

            foreach (var usuario in usuarios)
            {
                UsuariosDto usuarioDto = new UsuariosDto
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    IdEmpresa = usuario.IdEmpresa,
                    NomeEmpresa = usuario.Empresa != null ? usuario.Empresa.Nome : string.Empty,
                    DataCriacao = usuario.DataCriacao,
                    DataModificacao = usuario.DataModificacao,
                    PerguntaSecreta = usuario.PerguntaSecreta,
                    RespostaSecreta = usuario.RespostaSecreta
                };
                usuariosDto.Add(usuarioDto);

            }
            return usuariosDto;
        }

        [HttpPut]
        public IActionResult AtualizarUsuario([FromBody] UsuariosDto dados)
        {
            var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == dados.Id);

            if (usuario == null)
                return NotFound();

            usuario.DataModificacao = DateTime.Now;

            _mapper.Map(dados, usuario);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeletarUsuario(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);

            if (usuario == null)
                return NotFound();

            _context.Remove(usuario);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
