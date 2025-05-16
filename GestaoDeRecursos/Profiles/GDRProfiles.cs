using AutoMapper;
using ERP.Dto;
using ERP.Models;

namespace ERP.Profiles
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
