using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ERP.Models
{
    public class EntityProduct
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        public decimal Price { get; set; }

        [StringLength(50)]
        public string? Unit { get; set; } // Optional: e.g., "kg", "unit", "liters"

        [StringLength(100)]
        public string? Category { get; set; } // Optional: product classification

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public EntityCompany? Company { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int CreatedByUserId { get; set; }

        public int UpdatedByUserId { get; set; }
    }
}
