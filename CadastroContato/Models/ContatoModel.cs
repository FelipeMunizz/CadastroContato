using CadastroContato.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroContato.Models
{
    [Table("Contato")]
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome")]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Digite o E-mail")]
        [EmailAddress(ErrorMessage = "Este e-mial nao é valido")]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Digite o Celular")]
        [Phone(ErrorMessage = "O número não é valido")]
        public string? Celular { get; set; }

        [Required(ErrorMessage = "Digite o Serviço")]
        public string? Servico { get; set; }

        [Required(ErrorMessage = "Selecione o Status do Serviço")]
        public StatusEnum Status {get; set;}
    }
}
