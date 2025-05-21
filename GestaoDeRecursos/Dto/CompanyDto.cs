using System.ComponentModel.DataAnnotations;

namespace ERP.Dto
{
    public class CompanyDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }

    public class CompanyFilterDto { }
}
