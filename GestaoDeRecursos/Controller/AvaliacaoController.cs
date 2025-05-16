using AutoMapper;
using ERP.Data;
using ERP.Dto;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AvaliacaoController : ControllerBase
    {
        private GDRContext _context;
        private IMapper _mapper;

        public AvaliacaoController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public void AdicionarAvaliacao([FromBody] AvaliacaoDto avaliacao)
        {
            EntityAvaliacao entityAvaliacao = _mapper.Map<EntityAvaliacao>(avaliacao);
            entityAvaliacao.DataAvaliacao = DateTime.Now;
            _context.Avaliacaos.Add(entityAvaliacao);
            _context.SaveChanges();
        }

        [HttpGet]
        public IActionResult LerAvaliacaoPorId(int id)
        {
            var avaliacaoFiltrado = _context.Clientes.FirstOrDefault(avaliacao => avaliacao.Id == id);
            if (avaliacaoFiltrado == null)
                return NotFound();
            return Ok(avaliacaoFiltrado);
        }

        [HttpGet]
        public IActionResult LerAvaliacaoPorIdCliente(int id)
        {
            var avaliacaoClienteFiltrado = _context.Clientes.FirstOrDefault(avaliacao => avaliacao.Id == id);
            if (avaliacaoClienteFiltrado == null)
                return NotFound();
            return Ok(avaliacaoClienteFiltrado);
        }

        [HttpGet]
        public List<EntityAvaliacao> LerAvaliacao()
        {
            return _context.Avaliacaos.ToList();
        }

        [HttpPut]
        public IActionResult AtualizarAvaliacao([FromBody] AvaliacaoDto dados)
        {
            var avaliacao = _context.Avaliacaos.FirstOrDefault(avaliacao => avaliacao.Id == dados.Id);

            if (avaliacao == null)
                return NotFound();

            _mapper.Map(dados, avaliacao);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeletarAvaliacao(int id)
        {
            var avaliacao = _context.Clientes.FirstOrDefault(avaliacao => avaliacao.Id == id);

            if (avaliacao == null)
                return NotFound();

            _context.Remove(avaliacao);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
