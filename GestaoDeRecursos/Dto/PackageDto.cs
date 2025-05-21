namespace ERP.Dto
{
    public class PackageDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CompanyId { get; set; }

        public string? CompanyName { get; set; }

        public int CustomerId { get; set; }

        public string? CustomerName { get; set; }

        public int ServiceId { get; set; }

        public string? ServiceName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal Price { get; set; }

        public int TotalDays { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int CreatedByUserId { get; set; }

        public int UpdatedByUserId { get; set; }

        public int DaysUsed { get; set; }
    }

    public class PackageFilterDto { }
}
