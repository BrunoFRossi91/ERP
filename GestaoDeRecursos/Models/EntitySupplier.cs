using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class EntitySupplier
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        [StringLength(70)]
        public string ContactName { get; set; }

        [StringLength(70)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string TaxId { get; set; } // CNPJ or CPF

        [StringLength(200)]
        public string Address { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
