namespace ERP.Dto
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int CompanyId { get; set; }

        public string? CompanyName { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string SecurityQuestion { get; set; }

        public string SecurityAnswer { get; set; }
    }

    public class UserFilterDto { }
}
