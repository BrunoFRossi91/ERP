using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestaoDeRecursos.Models
{
    public class EntityServicos
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(70)]
        public string Nome { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        public decimal Valor { get; set; }

        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }
        public EntityEmpresa? Empresa { get; set; }

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }

        public int IdUsuarioCriacao { get; set; }

        public int IdUsuarioModificacao { get; set; }
    }
}
