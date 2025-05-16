using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class EntityCliente
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(70)]
        public string Nome { get; set; }

        [StringLength(70)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Senha { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }

        [StringLength(20)]
        public string Cpf { get; set; }

        [StringLength(200)]
        public string Endereco { get; set; }

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }

        public string PerguntaSecreta { get; set; }

        public string RespostaSecreta { get; set; }
    }
}
