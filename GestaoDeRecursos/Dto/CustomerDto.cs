namespace ERP.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Cpf { get; set; }

        public string Address { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public string SecretQuestion { get; set; }

        public string SecretAnswer { get; set; }

        public int CompanyId { get; set; }
    }

    public class CustomerFilterDto { }
}
