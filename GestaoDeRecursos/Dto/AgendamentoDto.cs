using GestaoDeRecursos.NewFolder;

namespace GestaoDeRecursos.Dto
{
    public class AgendamentoDto
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string NomeEmpresa { get; set; }
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public int IdServico { get; set; }
        public string NomeServico { get; set; }
        public int IdPacote { get; set; }
        public string NomePacote { get; set; }
        public DateTime? DataServico { get; set; }
        public int IdDiaSemana { get; set; }
        public TimeSpan Horario { get; set; } // Alterado para TimeSpan
        public int HoraInicioAtendimento { get; set; } // Alterado para int
        public int MinutoInicioAtendimento { get; set; } // Adicionado
        public int HoraFimAtendimento { get; set; } // Alterado para int
        public int MinutoFimAtendimento { get; set; } // Adicionado
        public decimal Valor { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataModificacao { get; set; }
        public int IdUsuarioCriacao { get; set; }
        public int IdUsuarioModificacao { get; set; }
        public bool Compareceu { get; set; }
        public StatusAgendamentoEnum? StatusAgendamento { get; set; }
    }
}
