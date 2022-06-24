using Microsoft.EntityFrameworkCore;

namespace CadastroContato.Models
{
    public class ContatoContext : DbContext
    {
        public ContatoContext(DbContextOptions<ContatoContext> options) : base(options)
        {
        }

        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
