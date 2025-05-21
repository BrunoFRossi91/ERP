using AutoMapper;
using ERP.Dto;
using ERP.Models;

namespace ERP.Profiles
{
    public class GDRProfiles : Profile
    {
        public GDRProfiles()
        {
            CreateMap<EmpresasDto, EntityCompany>();
            CreateMap<ClienteDto, EntityCustomer>();
            CreateMap<UsuariosDto, EntityUser>();
            CreateMap<UsuariosClienteDto, EntityCustomerUser>();
            CreateMap<PacotesDto, EntityPackage>();
            CreateMap<ServicosDto, EntityService>();
            CreateMap<DiaSemanaDto, EntityDiaSemana>();
            CreateMap<MetodoPagamentoDto, EntityMetodoPagamento>();
            CreateMap<ObrigacoesDto, EntityObrigacoes>();
            CreateMap<AgendamentoDto, EntityAgendamento>();
            CreateMap<AddAgendamentoDto, EntityAgendamento>();
            CreateMap<AvaliacaoDto, EntityAvaliacao>();
        }
    }
}
