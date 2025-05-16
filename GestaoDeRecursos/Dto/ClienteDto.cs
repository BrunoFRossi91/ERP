namespace GestaoDeRecursos.Dto
{
    public class ClienteDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Telefone { get; set; }

        public string Cpf { get; set; }

        public string Endereco { get; set; }

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }

        public string PerguntaSecreta { get; set; }

        public string RespostaSecreta { get; set; }

        public int IdEmpresa { get; set; }
    }

    public class ClienteFilterDto { }
}
