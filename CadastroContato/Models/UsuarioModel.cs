using CadastroContato.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroContato.Models
{
    [Table("Usuarios")]
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [MaxLength(16)]
        public string? Login { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public PerfilEnum Perfil { get; set; }        
        public string? Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
