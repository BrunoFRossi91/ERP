using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class EntityCompany
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(70)]
        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
