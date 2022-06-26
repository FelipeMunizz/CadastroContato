using System.ComponentModel.DataAnnotations;

namespace CadastroContato.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Login")]
        [MaxLength(16)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a Senha")]
        public string Senha { get; set; }
    }
}
