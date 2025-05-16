using System.ComponentModel;

namespace ERP.Enum
{
    public enum StatusAgendamentoEnum : int
    {
        [Description("Pendente")]
        Pendente = 1,

        [Description("Aprovado")]
        Aprovado = 2,

        [Description("Cancelado")]
        Cancelado = 3,
    }
}
