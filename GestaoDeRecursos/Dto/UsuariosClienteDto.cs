using System.ComponentModel.DataAnnotations.Schema;
using GestaoDeRecursos.Models;

namespace GestaoDeRecursos.Dto
{
    public class UsuariosClienteDto
    {
        public int Id { get; set; }

        public int IdCliente { get; set; }

        public int IdEmpresa { get; set; }

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }
    }
}
