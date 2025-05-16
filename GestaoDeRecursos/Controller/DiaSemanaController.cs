using AutoMapper;
using ERP.Data;
using ERP.Dto;
using ERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ERP.Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class DiaSemanaController : ControllerBase
    {
        private GDRContext _context;
        private IMapper _mapper;

        public DiaSemanaController(GDRContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public void AdicionarDiaSemana([FromBody] DiaSemanaDto diaSemanaDto)
        {
            var QtdAtendimentosDia = diaSemanaDto.QtdAtendimentosDia;
            var IntervaloEntreAtendimentos = diaSemanaDto.IntervaloEntreAtendimentos;

            for (int d = 0; d < QtdAtendimentosDia; d++)
            {
                EntityDiaSemana entityDiaSemana = _mapper.Map<EntityDiaSemana>(diaSemanaDto); // Criar uma nova instância em cada iteração
                entityDiaSemana.DataCriacao = DateTime.Now;

                // Dividir os valores de hora e minuto corretamente
                int horaInicio = diaSemanaDto.HoraInicioAtendimento; // A hora já está em formato inteiro
                int minutoInicio = diaSemanaDto.MinutoInicioAtendimento; // Obter os minutos diretamente do DTO

                // Calcular o horário de início com base no intervalo entre atendimentos
                var horaInicioSpan = new TimeSpan(horaInicio, minutoInicio, 0);
                horaInicioSpan = horaInicioSpan.Add(TimeSpan.FromMinutes(d * IntervaloEntreAtendimentos));

                // Calcular o horário de fim com base na duração do atendimento
                var horaFimSpan = horaInicioSpan.Add(TimeSpan.FromMinutes(IntervaloEntreAtendimentos));

                // Atribuir os valores ao EntityDiaSemana
                entityDiaSemana.HoraInicioAtendimento = horaInicioSpan;
                entityDiaSemana.HoraFimAtendimento = horaFimSpan;

                _context.DiaSemana.Add(entityDiaSemana);
            }

            _context.SaveChanges();
        }


        [HttpGet]
        public IActionResult LerDiaSemanaPorId(int id)
        {
            var diaSemanaFiltrado = _context.DiaSemana.FirstOrDefault(diaSemana => diaSemana.Id == id);
            if (diaSemanaFiltrado == null)
                return NotFound();
            return Ok(diaSemanaFiltrado);
        }

        [HttpGet]
        public List<DiaSemanaDto> LerDiaSemana()
        {
            List<EntityDiaSemana> diaSemanas = _context.DiaSemana.Include(e => e.Empresa).Include(s => s.Semana).ToList();
            List<DiaSemanaDto> diasSemanasDto = new List<DiaSemanaDto>();

            foreach (var diaSemana in diaSemanas)
            {
                DiaSemanaDto diaSemanaDto = new DiaSemanaDto
                {
                    Id = diaSemana.Id,
                    IdSemana = diaSemana.IdSemana,
                    NomeSemana = diaSemana.Semana != null ? diaSemana.Semana.Nome : string.Empty,
                    Util = diaSemana.Util,
                    IdEmpresa = diaSemana.IdEmpresa,
                    NomeEmpresa = diaSemana.Empresa != null ? diaSemana.Empresa.Nome : string.Empty,
                    DataCriacao = diaSemana.DataCriacao,
                    DataModificacao = diaSemana.DataModificacao,
                    // Ajuste para obter horas e minutos separadamente
                    HoraInicioAtendimento = diaSemana.HoraInicioAtendimento.Hours * 100 + diaSemana.HoraInicioAtendimento.Minutes,
                    HoraFimAtendimento = diaSemana.HoraFimAtendimento.Hours * 100 + diaSemana.HoraFimAtendimento.Minutes,
                };
                diasSemanasDto.Add(diaSemanaDto);
            }
            return diasSemanasDto;
        }

        [HttpPut]
        public IActionResult AtualizarDiaSemana([FromBody] DiaSemanaDto dados)
        {
            var diaSemana = _context.DiaSemana.FirstOrDefault(diaSemana => diaSemana.Id == dados.Id);

            if (diaSemana == null)
                return NotFound();

            diaSemana.DataModificacao = DateTime.Now;

            _mapper.Map(dados, diaSemana);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeletarDiaSemana(int id)
        {
            var diaSemana = _context.DiaSemana.FirstOrDefault(diaSemana => diaSemana.Id == id);

            if (diaSemana == null)
                return NotFound();

            _context.Remove(diaSemana);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComboxDto>>> ComboboxHorariosDisponiveisPorDia(int IdEmpresa, DateTime dia)
        {
            DayOfWeek diaDaSemana = dia.DayOfWeek;
            string nomeDiaDaSemana = dia.ToString("dddd", CultureInfo.GetCultureInfo("pt-BR"));

            var idDiaSemana = _context.Semana.Where(s => s.Nome == nomeDiaDaSemana).Select(s => s.Id).FirstOrDefault();

            var horariosPossiveis = _context.DiaSemana.Where(d => d.IdEmpresa == IdEmpresa).Where(d => d.IdSemana == idDiaSemana).Select(s => s.Id).ToList();

            var horarioUtilizadosNoDia = await _context.Agendamento.Where(p => p.IdEmpresa == IdEmpresa)
                                .Where(d => d.DataServico == dia).Select(s => s.IdDiaSemana).ToListAsync();

            var horariosNaoUtilizados = horariosPossiveis.Except(horarioUtilizadosNoDia).ToList();

            var diasSemanaNaoUtilizados = await _context.DiaSemana
                                            .Where(d => horariosNaoUtilizados.Contains(d.Id))
                                            .Select(e => new ComboxDto
                                            {
                                                Id = e.Id,
                                                Nome = e.Semana.Nome + " - " + (e.HoraInicioAtendimento.Hours * 100 + e.HoraInicioAtendimento.Minutes).ToString(),
                                            })
                                            .ToListAsync();

            return diasSemanaNaoUtilizados;
        }
    }
}
