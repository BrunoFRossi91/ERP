using AutoMapper;
using GestaoDeRecursos.Data;
using GestaoDeRecursos.Dto;
using GestaoDeRecursos.Models;
using GestaoDeRecursos.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeRecursos.Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AgendamentoController : ControllerBase
    {
        private GDRContext _context;
        private IMapper _mapper;

        public AgendamentoController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public void AdicionarAgenda([FromBody] AddAgendamentoDto agenda)
        {
            var clienteFiltrado = _context.Clientes.FirstOrDefault(cliente => cliente.Email == agenda.EmailCliente);
            agenda.IdCliente = clienteFiltrado.Id;
            EntityAgendamento entityAgendamento = _mapper.Map<EntityAgendamento>(agenda);
            entityAgendamento.DataCriacao = DateTime.Now;
            _context.Agendamento.Add(entityAgendamento);
            _context.SaveChanges();
        }

        [HttpGet]
        public IActionResult LerAgendaPorId(int id)
        {
            var agendamentoFiltrado = _context.Agendamento.FirstOrDefault(cliente => cliente.Id == id);
            if (agendamentoFiltrado == null)
                return NotFound();
            return Ok(agendamentoFiltrado);
        }

        [HttpGet]
        public List<AgendamentoDto> LerAgendamentos()
        {

            List<EntityAgendamento> agendamentos = _context.Agendamento.Include(e => e.Empresa).Include(s => s.Servico).Include(p => p.Pacotes).Include(d => d.DiaSemana).ToList();
            List<AgendamentoDto> agendamentosDto = new List<AgendamentoDto>();

            foreach (var agendamento in agendamentos)
            {
                AgendamentoDto agendamentoDto = new AgendamentoDto
                {
                    Id = agendamento.Id,
                    IdEmpresa = agendamento.IdEmpresa,
                    NomeEmpresa = agendamento.Empresa != null ? agendamento.Empresa.Nome : string.Empty,
                    IdPacote = agendamento.IdPacote,
                    NomePacote = agendamento.Pacotes != null ? agendamento.Pacotes.Nome : string.Empty,
                    IdServico = agendamento.IdServico,
                    NomeServico = agendamento.Servico != null ? agendamento.Servico.Nome : string.Empty,
                    DataCriacao = agendamento.DataCriacao,
                    DataModificacao = agendamento.DataModificacao,
                    DataServico = agendamento.DataServico,
                    Valor = agendamento.Valor,
                    IdDiaSemana = agendamento.IdDiaSemana,
                    Horario = agendamento.DiaSemana != null ? agendamento.DiaSemana.HoraInicioAtendimento : TimeSpan.Zero,
                    //Cancelado = agendamento.Cancelado,
                };
                agendamentosDto.Add(agendamentoDto);

            }
            return agendamentosDto;
        }

        [HttpPut]
        public IActionResult AtualizarAgendamento([FromBody] AgendamentoDto dados)
        {
            var agendamento = _context.Agendamento.FirstOrDefault(agendamento => agendamento.Id == dados.Id);

            if (agendamento == null)
                return NotFound();

            agendamento.DataModificacao = DateTime.Now;

            _mapper.Map(dados, agendamento);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut]
        public IActionResult CancelarAgendamento(int id)
        {
            var agendamento = _context.Agendamento.FirstOrDefault(agendamento => agendamento.Id == id);

            if (agendamento == null)
                return NotFound();

            agendamento.DataModificacao = DateTime.Now;

            agendamento.StatusAgendamento = StatusAgendamentoEnum.Cancelado;

            _context.SaveChanges();

            return NoContent();
        }

        //[HttpDelete]
        //public IActionResult DeletarCliente(int id)
        //{
        //    var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);

        //    if (cliente == null)
        //        return NotFound();

        //    _context.Remove(cliente);
        //    _context.SaveChanges();
        //    return NoContent();
        //}
    }
}
