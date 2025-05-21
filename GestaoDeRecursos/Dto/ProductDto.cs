namespace ERP.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? Unit { get; set; }

        public string? Category { get; set; }

        public int CompanyId { get; set; }

        public string? CompanyName { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int CreatedByUserId { get; set; }

        public int UpdatedByUserId { get; set; }
    }

    public class ProductFilterDto { }
}
