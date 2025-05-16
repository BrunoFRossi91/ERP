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

    public class ObrigacoesController : ControllerBase
    {
        private GDRContext _context;
        private IMapper _mapper;

        public ObrigacoesController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public void AdicionarObrigacao([FromBody] ObrigacoesDto obrigacoes)
        {
            EntityObrigacoes entityObrigacoes = _mapper.Map<EntityObrigacoes>(obrigacoes);
            entityObrigacoes.DataCriacao = DateTime.Now;
            _context.Obrigacacoes.Add(entityObrigacoes);
            _context.SaveChanges();
        }

        [HttpGet]
        public IActionResult LerObrigacaoPorId(int id)
        {
            var obrigacaoFiltrado = _context.Obrigacacoes.FirstOrDefault(obrigacao => obrigacao.Id == id);
            if (obrigacaoFiltrado == null)
                return NotFound();
            return Ok(obrigacaoFiltrado);
        }

        [HttpGet]
        public List<ObrigacoesDto> LerObrigacoes()
        {
            List<EntityObrigacoes> obrigacoes = _context.Obrigacacoes.Include(e => e.Empresa).ToList();
            List<ObrigacoesDto> oborgacoesDto = new List<ObrigacoesDto>();

            foreach (var obrigacao in obrigacoes)
            {
                ObrigacoesDto obrigacaoDto = new ObrigacoesDto
                {
                    Id = obrigacao.Id,
                    Nome = obrigacao.Nome,
                    Valor = obrigacao.Valor,
                    IdEmpresa = obrigacao.IdEmpresa,
                    NomeEmpresa = obrigacao.Empresa != null ? obrigacao.Empresa.Nome : string.Empty,
                    DataCriacao = obrigacao.DataCriacao,
                    DataModificacao = obrigacao.DataModificacao,
                    DataVencimento = obrigacao.DataVencimento
                };
                oborgacoesDto.Add(obrigacaoDto);

            }
            return oborgacoesDto;
        }

        [HttpPut]
        public IActionResult AtualizarObrigacao([FromBody] ObrigacoesDto dados)
        {
            var obrigacao = _context.Obrigacacoes.FirstOrDefault(obrigacao => obrigacao.Id == dados.Id);

            if (obrigacao == null)
                return NotFound();

            obrigacao.DataModificacao = DateTime.Now;

            _mapper.Map(dados, obrigacao);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeletarObrigacao(int id)
        {
            var obrigacao = _context.Obrigacacoes.FirstOrDefault(obrigacao => obrigacao.Id == id);

            if (obrigacao == null)
                return NotFound();

            _context.Remove(obrigacao);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
