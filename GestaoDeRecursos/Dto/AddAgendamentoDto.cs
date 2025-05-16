namespace ERP.Dto
{
    public class AddAgendamentoDto
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string EmailCliente { get; set; }
        public int IdServico { get; set; }
        public int IdPacote { get; set; }
        public DateTime? DataServico { get; set; }
        public int IdDiaSemana { get; set; }
        public int IdCliente { get; set; }
    }
}
