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

    public class MetodoPagamentoController : ControllerBase
    {
        private GDRContext _context;
        private IMapper _mapper;

        public MetodoPagamentoController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpPost]
        public void AdicionarMetodoPagamento([FromBody] MetodoPagamentoDto metodoPgt)
        {
            EntityMetodoPagamento entityMetodoPagamento = _mapper.Map<EntityMetodoPagamento>(metodoPgt);
            entityMetodoPagamento.DataCriacao = DateTime.Now;
            _context.MetodoPagamento.Add(entityMetodoPagamento);
            _context.SaveChanges();
        }

        [HttpGet]
        public IActionResult LerMetodoPagamentooPorId(int id)
        {
            var metodoPgtFiltrado = _context.MetodoPagamento.FirstOrDefault(metodoPgt => metodoPgt.Id == id);
            if (metodoPgtFiltrado == null)
                return NotFound();
            return Ok(metodoPgtFiltrado);
        }

        [HttpGet]
        public List<MetodoPagamentoDto> LerMetodoPagamento()
        {
            List<EntityMetodoPagamento> metodosPagamento = _context.MetodoPagamento.Include(e => e.Empresa).ToList();
            List<MetodoPagamentoDto> metodosPagamentoDto = new List<MetodoPagamentoDto>();

            foreach (var metodoPagamento in metodosPagamento)
            {
                MetodoPagamentoDto metodoPagamentoDto = new MetodoPagamentoDto
                {
                    Id = metodoPagamento.Id,
                    Nome = metodoPagamento.Nome,
                    IdEmpresa = metodoPagamento.IdEmpresa,
                    NomeEmpresa = metodoPagamento.Empresa != null ? metodoPagamento.Empresa.Nome : string.Empty,
                    DataCriacao = metodoPagamento.DataCriacao,
                    DataModificacao = metodoPagamento.DataModificacao,
                };
                metodosPagamentoDto.Add(metodoPagamentoDto);

            }
            return metodosPagamentoDto;
        }

        [HttpPut]
        public IActionResult AtualizarMetodoPagamento([FromBody] MetodoPagamentoDto dados)
        {
            var metodoPgt = _context.MetodoPagamento.FirstOrDefault(metodoPgt => metodoPgt.Id == dados.Id);

            if (metodoPgt == null)
                return NotFound();

            metodoPgt.DataModificacao = DateTime.Now;

            _mapper.Map(dados, metodoPgt);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeletarMetodoPagamento(int id)
        {
            var metodoPgt = _context.MetodoPagamento.FirstOrDefault(metodoPgt => metodoPgt.Id == id);

            if (metodoPgt == null)
                return NotFound();

            _context.Remove(metodoPgt);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
