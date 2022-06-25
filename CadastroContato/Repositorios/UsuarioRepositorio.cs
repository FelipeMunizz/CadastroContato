using CadastroContato.Models;

namespace CadastroContato.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ContatoContext _contatoContext;
        public UsuarioRepositorio(ContatoContext contatoContext)
        {
            _contatoContext = contatoContext;
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _contatoContext.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            //gravar no banco
            _contatoContext.Usuarios.Add(usuario);
            _contatoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel ListarId(int id)
        {
            return _contatoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = ListarId(usuario.Id);
            if (usuarioDb == null) throw new Exception("Houve um erro na atualização do usuário");
            {
                usuarioDb.Nome = usuario.Nome;
                usuarioDb.Email = usuario.Email;
                usuarioDb.Login = usuario.Login;
                usuarioDb.Perfil = usuario.Perfil;
                usuarioDb.DataAtualizacao = DateTime.Now;

                _contatoContext.Usuarios.Update(usuarioDb);
                _contatoContext.SaveChanges();

                return usuarioDb;
            }
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDb = ListarId(id);
            if (usuarioDb == null) throw new Exception("Houve um erro na Exclusão do usuário");
            _contatoContext.Usuarios.Remove(usuarioDb);
            _contatoContext.SaveChanges();
            return true;
        }
    }
}
