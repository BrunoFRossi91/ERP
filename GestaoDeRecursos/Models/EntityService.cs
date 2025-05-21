using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class EntityService
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(70)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        public decimal Price { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public EntityCompany? Company { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int CreatedByUserId { get; set; }

        public int UpdatedByUserId { get; set; }
    }
}
