using AutoMapper;
using GestaoDeRecursos.Data;
using GestaoDeRecursos.Dto;
using GestaoDeRecursos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeRecursos.Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmpresaController : ControllerBase
    {
        private readonly EntityEmpresa _empresaRepository;

        private GDRContext _context;
        private IMapper _mapper;

        public EmpresaController(
            GDRContext context,
            EntityEmpresa empresaRepository,
            IMapper mapper
        )
        {
            _context = context;
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public void AdicionarEmpresa([FromBody] EmpresasDto empresa)
        {
            EntityEmpresa entityEmpresa = _mapper.Map<EntityEmpresa>(empresa);
            _context.Empresa.Add(entityEmpresa);
            _context.SaveChanges();
        }


        [HttpGet]
        public IActionResult LerEmpresaPorId(int id)
        {
            var empresaFiltrada = _context.Empresa.FirstOrDefault(empresa => empresa.Id == id);
            if (empresaFiltrada == null)
                return NotFound();
            return Ok(empresaFiltrada);
        }

        [HttpGet]
        public List<EntityEmpresa> LerEmpresas()
        {
            return _context.Empresa.ToList();
        }

        [HttpPut]
        public IActionResult AtualizarEmpresa([FromBody] EmpresasDto dados)
        {
            var empresa = _context.Empresa.FirstOrDefault(empresa => empresa.Id == dados.Id);

            if (empresa == null)
                return NotFound();

            _mapper.Map(dados, empresa);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeletarEmpresa(int id)
        {
            var empresa = _context.Empresa.FirstOrDefault(empresa => empresa.Id == id);

            if (empresa == null)
                return NotFound();

            _context.Remove(empresa);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComboxDto>>> ComboboxEmpresa()
        {
            var empresa = await _context.Empresa.Select(e => new ComboxDto
            {
                Id = e.Id,
                Nome = e.Nome
            }).ToListAsync();

            return empresa;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComboxDto>>> ComboboxEmpresaPorCliente(int IdCliente)
        {
            var usuario = await _context.UsuariosClientes.Select(u => u.IdCliente).ToListAsync();

            var empresa = await _context.Empresa.Where(e => usuario.Contains(e.Id))
                                .Select(e => new ComboxDto
                                {
                                    Id = e.Id,
                                    Nome = e.Nome
                                })
                                .ToListAsync();

            return empresa;
        }
    }
}
