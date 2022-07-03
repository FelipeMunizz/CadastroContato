using CadastroContato.Data;
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
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _contatoContext.Usuarios.Add(usuario);
            _contatoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel ListarId(int id)
        {
            return _contatoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _contatoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel BuscarPorEmailELogin(string email, string login)
        {
            return _contatoContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarId(usuario.Id);

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização do usuário!");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;

            _contatoContext.Usuarios.Update(usuarioDB);
            _contatoContext.SaveChanges();

            return usuarioDB;
        }

        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenha)
        {
            UsuarioModel usuarioDb = ListarId(alterarSenha.Id);

            if (usuarioDb == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado!");
            if (!usuarioDb.SenhaValida(alterarSenha.SenhaAtual)) throw new Exception("Senha atual não confere!");
            if (usuarioDb.SenhaValida(alterarSenha.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual");
            usuarioDb.SetNovaSenha(alterarSenha.NovaSenha);
            usuarioDb.DataAtualizacao = DateTime.Now;
            _contatoContext.Usuarios.Update(usuarioDb);
            _contatoContext.SaveChanges();
            return usuarioDb;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDb = ListarId(id);
            if (usuarioDb == null) throw new Exception("Houve um erro na Exclusão do usuário!");
            _contatoContext.Usuarios.Remove(usuarioDb);
            _contatoContext.SaveChanges();
            return true;
        }


    }
}
