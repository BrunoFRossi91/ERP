using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class EntityEmpresa
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(70)]
        public string Nome { get; set; }

        public DateTime? DataInicioVigencia { get; set; }

        public DateTime? DataFimVigencia { get; set; }
    }
}
