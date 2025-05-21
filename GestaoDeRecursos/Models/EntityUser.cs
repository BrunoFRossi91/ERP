using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class EntityUser
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(70)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public EntityCompany? Company { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string SecurityQuestion { get; set; }

        public string SecurityAnswer { get; set; }
    }
}
