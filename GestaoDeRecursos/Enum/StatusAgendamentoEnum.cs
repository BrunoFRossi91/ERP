using System.ComponentModel;

namespace GestaoDeRecursos.NewFolder
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
