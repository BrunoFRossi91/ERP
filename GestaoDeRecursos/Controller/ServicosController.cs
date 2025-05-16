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
    public class ServicosController : ControllerBase
    {
        private GDRContext _context;
        private IMapper _mapper;

        public ServicosController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpPost]
        public void AdicionarServico([FromBody] ServicosDto servicos)
        {
            EntityServicos entityServicos = _mapper.Map<EntityServicos>(servicos);
            entityServicos.DataCriacao = DateTime.Now;
            _context.Servicos.Add(entityServicos);
            _context.SaveChanges();
        }

        [HttpGet]
        public IActionResult LerServicoPorId(int id)
        {
            var servicoFiltrado = _context.Servicos.FirstOrDefault(servico => servico.Id == id);
            if (servicoFiltrado == null)
                return NotFound();
            return Ok(servicoFiltrado);
        }

        [HttpGet]
        public List<ServicosDto> LerServicos()
        {

            List<EntityServicos> servicos = _context.Servicos.Include(e => e.Empresa).ToList();
            List<ServicosDto> servicosDto = new List<ServicosDto>();

            foreach (var servico in servicos)
            {
                ServicosDto servicoDto = new ServicosDto
                {
                    Id = servico.Id,
                    Nome = servico.Nome,
                    Valor = servico.Valor,
                    IdEmpresa = servico.IdEmpresa,
                    NomeEmpresa = servico.Empresa != null ? servico.Empresa.Nome : string.Empty,
                    DataCriacao = servico.DataCriacao,
                    DataModificacao = servico.DataModificacao,
                };
                servicosDto.Add(servicoDto);

            }
            return servicosDto;
        }

        [HttpPut]
        public IActionResult AtualizarServico([FromBody] ServicosDto dados)
        {
            var servico = _context.Servicos.FirstOrDefault(servico => servico.Id == dados.Id);

            if (servico == null)
                return NotFound();

            servico.DataModificacao = DateTime.Now;

            _mapper.Map(dados, servico);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeletarServico(int id)
        {
            var servico = _context.Servicos.FirstOrDefault(servico => servico.Id == id);

            if (servico == null)
                return NotFound();

            _context.Remove(servico);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComboxDto>>> ComboboxServicoPorEmpresa(int IdEmpresa)
        {
            var servico = await _context.Servicos.Where(s => s.IdEmpresa == IdEmpresa)
                                .Select(e => new ComboxDto
                                {
                                    Id = e.Id,
                                    Nome = e.Nome
                                })
                                .ToListAsync();

            return servico;
        }
    }
}
