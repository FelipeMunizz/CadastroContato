using System.ComponentModel.DataAnnotations;

namespace CadastroContato.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o Login")]
        [MaxLength(16)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a Email")]
        public string Email { get; set; }
    }
}
