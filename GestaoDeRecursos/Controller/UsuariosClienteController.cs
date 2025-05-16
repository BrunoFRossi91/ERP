using AutoMapper;
using GestaoDeRecursos.Data;
using GestaoDeRecursos.Dto;
using GestaoDeRecursos.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeRecursos.Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsuariosClienteController : ControllerBase
    {
        private GDRContext _context;
        private IMapper _mapper;

        public UsuariosClienteController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public void AdicionarUsuariosCliente([FromBody] UsuariosClienteDto cliente)
        {
            EntityUsuariosCliente EntityUsuariosCliente = _mapper.Map<EntityUsuariosCliente>(
                cliente
            );
            EntityUsuariosCliente.DataCriacao = DateTime.Now;
            _context.UsuariosClientes.Add(EntityUsuariosCliente);
            _context.SaveChanges();
        }

        [HttpGet]
        public IActionResult LerUsuariosClientePorId(int id)
        {
            var usuarioClienteFiltrado = _context.UsuariosClientes.FirstOrDefault(usuarioCliente =>
                usuarioCliente.Id == id
            );
            if (usuarioClienteFiltrado == null)
                return NotFound();
            return Ok(usuarioClienteFiltrado);
        }

        [HttpGet]
        public List<EntityUsuariosCliente> LerClientes()
        {
            return _context.UsuariosClientes.ToList();
        }

        [HttpPut]
        public IActionResult AtualizarUsuariosCliente([FromBody] UsuariosClienteDto dados)
        {
            var usuarioCliente = _context.UsuariosClientes.FirstOrDefault(usuarioCliente =>
                usuarioCliente.Id == dados.Id
            );

            if (usuarioCliente == null)
                return NotFound();

            usuarioCliente.DataModificacao = DateTime.Now;

            _mapper.Map(dados, usuarioCliente);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeletarUsuariosCliente(int id)
        {
            var usuarioCliente = _context.UsuariosClientes.FirstOrDefault(usuarioCliente =>
                usuarioCliente.Id == id
            );

            if (usuarioCliente == null)
                return NotFound();

            _context.Remove(usuarioCliente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
