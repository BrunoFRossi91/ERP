namespace ERP.Dto
{
    public class SupplierDto
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string TaxId { get; set; } // CNPJ or CPF

        public string Address { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }

    public class SupplierFilterDto { }
}
