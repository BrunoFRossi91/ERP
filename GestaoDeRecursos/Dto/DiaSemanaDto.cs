namespace GestaoDeRecursos.Dto
{
    public class DiaSemanaDto
    {

        public int Id { get; set; }
        public int IdSemana { get; set; }
        public string? NomeSemana { get; set; }
        public bool Util { get; set; }
        public int IdEmpresa { get; set; }
        public string? NomeEmpresa { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataModificacao { get; set; }
        public int IdUsuarioCriacao { get; set; }
        public int IdUsuarioModificacao { get; set; }
        public int HoraInicioAtendimento { get; set; } // Alterado para int
        public int MinutoInicioAtendimento { get; set; } // Adicionado
        public int HoraFimAtendimento { get; set; } // Alterado para int
        public int MinutoFimAtendimento { get; set; } // Adicionado
        public int QtdAtendimentosDia { get; set; }
        public int IntervaloEntreAtendimentos { get; set; }
    }
}
