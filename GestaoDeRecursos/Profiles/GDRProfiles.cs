using AutoMapper;
using GestaoDeRecursos.Dto;
using GestaoDeRecursos.Models;

namespace GestaoDeRecursos.Profiles
{
    public class GDRProfiles : Profile
    {
        public GDRProfiles()
        {
            CreateMap<EmpresasDto, EntityEmpresa>();
            CreateMap<ClienteDto, EntityCliente>();
            CreateMap<UsuariosDto, EntityUsuarios>();
            CreateMap<UsuariosClienteDto, EntityUsuariosCliente>();
            CreateMap<PacotesDto, EntityPacote>();
            CreateMap<ServicosDto, EntityServicos>();
            CreateMap<DiaSemanaDto, EntityDiaSemana>();
            CreateMap<MetodoPagamentoDto, EntityMetodoPagamento>();
            CreateMap<ObrigacoesDto, EntityObrigacoes>();
            CreateMap<AgendamentoDto, EntityAgendamento>();
            CreateMap<AddAgendamentoDto, EntityAgendamento>();
            CreateMap<AvaliacaoDto, EntityAvaliacao>();
        }
    }
}
