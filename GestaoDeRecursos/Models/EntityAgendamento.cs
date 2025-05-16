using ERP.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class EntityAgendamento
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }
        public EntityEmpresa? Empresa { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public EntityCliente? Cliente { get; set; }

        [ForeignKey("Servico")]
        public int IdServico { get; set; }
        public EntityServicos? Servico { get; set; }

        [ForeignKey("Pacotes")]
        public int IdPacote { get; set; }
        public EntityPacote? Pacotes { get; set; }

        public DateTime? DataServico { get; set; }

        [ForeignKey("DiaSemana")]
        public int IdDiaSemana { get; set; }
        public EntityDiaSemana? DiaSemana { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        public decimal Valor { get; set; }

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }

        public int IdUsuarioCriacao { get; set; }

        public int IdUsuarioModificacao { get; set; }

        public bool Compareceu { get; set; }

        public StatusAgendamentoEnum StatusAgendamento { get; set; }

    }
}
