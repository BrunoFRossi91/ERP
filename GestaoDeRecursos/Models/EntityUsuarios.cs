using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class EntityUsuarios
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(70)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Senha { get; set; }

        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }
        public EntityEmpresa? Empresa { get; set; }

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }

        public string PerguntaSecreta { get; set; }

        public string RespostaSecreta { get; set; }
    }
}
