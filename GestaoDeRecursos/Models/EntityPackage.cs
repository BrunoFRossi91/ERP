using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class EntityPackage
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(70)]
        public string Name { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public EntityCompany? Company { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public EntityCustomer? Customer { get; set; }

        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public EntityService? Service { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Column(TypeName = "decimal(18,5)")]
        public decimal Price { get; set; }

        public int NumberOfDays { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int CreatedByUserId { get; set; }

        public int UpdatedByUserId { get; set; }
    }
}
