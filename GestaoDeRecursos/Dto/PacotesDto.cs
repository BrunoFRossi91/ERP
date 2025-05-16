namespace GestaoDeRecursos.Dto
{
    public class PacotesDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int IdEmpresa { get; set; }

        public string? NomeEmpresa { get; set; }

        public int IdCliente { get; set; }

        public string? NomeCliente { get; set; }

        public int IdServico { get; set; }

        public string? NomeServico { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public decimal Valor { get; set; }

        public int QuantidadeDias { get; set; }

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }

        public int IdUsuarioCriacao { get; set; }

        public int IdUsuarioModificacao { get; set; }

        public int QtdDiasUtilizado { get; set; }
    }

    public class PacotesFilterDto { }
}
