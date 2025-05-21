using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class EntityEmployee
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(70)]
        public string Name { get; set; }

        [StringLength(70)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string TaxId { get; set; } // CPF or similar

        [StringLength(200)]
        public string Address { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? HireDate { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
