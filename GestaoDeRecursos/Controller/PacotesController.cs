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
    public class PacotesController : ControllerBase
    {
        private GDRContext _context;
        private IMapper _mapper;

        public PacotesController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public void AdicionarPacote([FromBody] PacotesDto pacotes)
        {
            EntityPacote entityPacote = _mapper.Map<EntityPacote>(pacotes);
            entityPacote.DataCriacao = DateTime.Now;
            _context.Pacote.Add(entityPacote);
            _context.SaveChanges();
        }

        [HttpGet]
        public PacotesDto LerPacotePorId(int id)
        {
            var qtdDiasUsados = 0;
            var pacoteFiltrado = _context.Pacote.Include(e => e.Empresa).Include(e => e.Cliente).Include(e => e.Servico).FirstOrDefault(pacote => pacote.Id == id);

            var diasPacote = pacoteFiltrado.QuantidadeDias;
            qtdDiasUsados = _context.Agendamento.Where(d => d.DataServico >= pacoteFiltrado.DataInicio).Where(d => d.DataServico <= pacoteFiltrado.DataFim).Count(p => p.IdPacote == id);

            PacotesDto pacoteDto = new PacotesDto
            {
                Id = pacoteFiltrado.Id,
                Nome = pacoteFiltrado.Nome,
                IdEmpresa = pacoteFiltrado.IdEmpresa,
                NomeEmpresa = pacoteFiltrado.Empresa != null ? pacoteFiltrado.Empresa.Nome : string.Empty,
                IdCliente = pacoteFiltrado.IdCliente,
                NomeCliente = pacoteFiltrado.Cliente != null ? pacoteFiltrado.Cliente.Nome : string.Empty,
                IdServico = pacoteFiltrado.IdServico,
                NomeServico = pacoteFiltrado.Servico != null ? pacoteFiltrado.Servico.Nome : string.Empty,
                DataInicio = pacoteFiltrado.DataInicio,
                DataFim = pacoteFiltrado.DataFim,
                Valor = pacoteFiltrado.Valor,
                QuantidadeDias = pacoteFiltrado.QuantidadeDias,
                DataCriacao = pacoteFiltrado.DataCriacao,
                DataModificacao = pacoteFiltrado.DataModificacao,
                QtdDiasUtilizado = qtdDiasUsados,
            };


            return pacoteDto;
        }

        [HttpGet]
        public List<PacotesDto> LerPacotes()
        {

            List<EntityPacote> pacotes = _context.Pacote.Include(e => e.Empresa).Include(e => e.Cliente).Include(e => e.Servico).ToList();
            List<PacotesDto> pacotesDto = new List<PacotesDto>();

            foreach (var pacote in pacotes)
            {
                PacotesDto pacoteDto = new PacotesDto
                {
                    Id = pacote.Id,
                    Nome = pacote.Nome,
                    IdEmpresa = pacote.IdEmpresa,
                    NomeEmpresa = pacote.Empresa != null ? pacote.Empresa.Nome : string.Empty,
                    IdCliente = pacote.IdCliente,
                    NomeCliente = pacote.Cliente != null ? pacote.Cliente.Nome : string.Empty,
                    IdServico = pacote.IdServico,
                    NomeServico = pacote.Servico != null ? pacote.Servico.Nome : string.Empty,
                    DataInicio = pacote.DataInicio,
                    DataFim = pacote.DataFim,
                    Valor = pacote.Valor,
                    QuantidadeDias = pacote.QuantidadeDias,
                    DataCriacao = pacote.DataCriacao,
                    DataModificacao = pacote.DataModificacao,
                };
                pacotesDto.Add(pacoteDto);

            }
            return pacotesDto;
        }

        [HttpPut]
        public IActionResult AtualizarPacote([FromBody] PacotesDto dados)
        {
            var pacote = _context.Pacote.FirstOrDefault(pacote => pacote.Id == dados.Id);

            if (pacote == null)
                return NotFound();

            pacote.DataModificacao = DateTime.Now;

            _mapper.Map(dados, pacote);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeletarPacote(int id)
        {
            var pacote = _context.Pacote.FirstOrDefault(pacote => pacote.Id == id);

            if (pacote == null)
                return NotFound();

            _context.Remove(pacote);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComboxDto>>> ComboboxPacotePorEmpresaCliente(int IdEmpresa, string emailCliente)
        {
            var cliente = _context.Clientes.Where(c => c.Email == emailCliente).Select(c => c.Id).FirstOrDefault();

            var servico = await _context.Pacote.Where(p => p.IdEmpresa == IdEmpresa)
                                .Where(p => p.IdCliente == cliente)
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
