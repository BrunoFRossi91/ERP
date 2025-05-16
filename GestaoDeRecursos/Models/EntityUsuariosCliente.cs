using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class EntityUsuariosCliente
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public EntityCliente? Cliente { get; set; }

        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }
        public EntityEmpresa? Empresa { get; set; }

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }
    }
}
