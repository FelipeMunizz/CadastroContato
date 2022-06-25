using CadastroContato.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroContato.Models
{

    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome")]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Digite o Login")]
        [MaxLength(16)]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Digite o E-mail")]
        [EmailAddress(ErrorMessage = "Este e-mial nao é valido")]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Selecione o Perfil")]
        public PerfilEnum? Perfil { get; set; }
    }
}
