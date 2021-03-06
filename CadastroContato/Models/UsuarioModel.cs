using CadastroContato.Enum;
using CadastroContato.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroContato.Models
{
    [Table("Usuarios")]
    public class UsuarioModel
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

        [Required(ErrorMessage = "Digite a Senha")]
        public string? Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarRash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarRash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarRash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarRash();
            return novaSenha;
        }
    }
}
