using AutoMapper;
using ERP.Data;
using ERP.Dto;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClienteController : ControllerBase
    {
        private GDRContext _context;
        private IMapper _mapper;

        public ClienteController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public void AdicionarCliente([FromBody] ClienteDto cliente)
        {
            EntityCliente entityCliente = _mapper.Map<EntityCliente>(cliente);
            entityCliente.DataCriacao = DateTime.Now;
            entityCliente.DataModificacao = null;
            _context.Clientes.Add(entityCliente);
            _context.SaveChanges();

            // Obtém o ID do cliente recém-criado
            int clienteId = entityCliente.Id;

            // Cria a entidade de usuário cliente usando o ID do cliente e o ID da empresa
            EntityUsuariosCliente entityUsuariosCliente = new EntityUsuariosCliente
            {
                IdCliente = clienteId,  // Define o ID do cliente
                IdEmpresa = cliente.IdEmpresa,  // Define o ID da empresa do cliente
                DataCriacao = DateTime.Now,
                DataModificacao = null// Outros campos do usuário cliente, se houver
            };

            // Adiciona a entidade de usuário cliente ao contexto e salva as alterações
            _context.UsuariosClientes.Add(entityUsuariosCliente);
            _context.SaveChanges();
        }

        [HttpGet]
        public IActionResult LerClientePorId(int id)
        {
            var clienteFiltrado = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (clienteFiltrado == null)
                return NotFound();
            return Ok(clienteFiltrado);
        }

        [HttpGet]
        public List<EntityCliente> LerClientes()
        {
            return _context.Clientes.ToList();
        }

        [HttpPut]
        public IActionResult AtualizarCliente([FromBody] ClienteDto dados)
        {
            var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == dados.Id);

            if (cliente == null)
                return NotFound();

            cliente.DataModificacao = DateTime.Now;

            _mapper.Map(dados, cliente);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeletarCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);

            if (cliente == null)
                return NotFound();

            _context.Remove(cliente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
