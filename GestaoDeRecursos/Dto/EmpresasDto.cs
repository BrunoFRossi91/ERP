using System.ComponentModel.DataAnnotations;

namespace ERP.Dto
{
    public class EmpresasDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime? DataInicioVigencia { get; set; }

        public DateTime? DataFimVigencia { get; set; }
    }

    public class EmpresasFilterDto { }
}
