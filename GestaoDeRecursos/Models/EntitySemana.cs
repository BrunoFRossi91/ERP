using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class EntitySemana
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(70)]
        public string Nome { get; set; }
    }
}
