namespace GestaoDeRecursos.Dto
{
    public class AvaliacaoDto
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public double CoxaDireita { get; set; }
        public double CoxaEsquerda { get; set; }
        public double PanturrilhaDireita { get; set; }
        public double PanturrilhaEsquerda { get; set; }
        public double Gluteo { get; set; }
        public double BracoDireito { get; set; }
        public double BracoEsquerdo { get; set; }
        public double Peito { get; set; }
        public double AbdomenInfra { get; set; }
        public double AbdomenSupra { get; set; }
        public DateTime? DataAvaliacao { get; set; }
    }
}
