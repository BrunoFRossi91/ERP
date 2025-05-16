using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoDeRecursos.Models
{
    public class EntityDiaSemana
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Semana")]
        public int IdSemana { get; set; }
        public EntitySemana? Semana { get; set; }
        public TimeSpan HoraInicioAtendimento { get; set; } // Alterado para TimeSpan
        public TimeSpan HoraFimAtendimento { get; set; } // Alterado para TimeSpan

        public bool Util { get; set; }

        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }
        public EntityEmpresa? Empresa { get; set; }

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }

        public int IdUsuarioCriacao { get; set; }

        public int IdUsuarioModificacao { get; set; }
    }
}
