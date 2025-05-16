namespace ERP.Dto
{
    public class ObrigacoesDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public int IdEmpresa { get; set; }

        public string? NomeEmpresa { get; set; }

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }

        public int IdUsuarioCriacao { get; set; }

        public int IdUsuarioModificacao { get; set; }
        public DateTime? DataVencimento { get; set; }
    }
}
