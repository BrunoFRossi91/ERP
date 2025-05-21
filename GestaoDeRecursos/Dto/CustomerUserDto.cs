using System.ComponentModel.DataAnnotations.Schema;
using ERP.Models;

namespace ERP.Dto
{
    public class CustomerUserDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int CompanyId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}
