namespace ERP.Dto
{
    public class UsuariosDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public int IdEmpresa { get; set; }

        public string? NomeEmpresa { get; set; }

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }

        public string PerguntaSecreta { get; set; }

        public string RespostaSecreta { get; set; }
    }
}
