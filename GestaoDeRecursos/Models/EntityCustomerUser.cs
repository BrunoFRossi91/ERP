using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class EntityCustomerUser
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public EntityCustomer? Customer { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public EntityCompany? Company { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
