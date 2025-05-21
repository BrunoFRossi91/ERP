using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class EntityCustomer
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(70)]
        public string Name { get; set; }

        [StringLength(70)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string TaxId { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string SecurityQuestion { get; set; }

        public string SecurityAnswer { get; set; }
    }
}
