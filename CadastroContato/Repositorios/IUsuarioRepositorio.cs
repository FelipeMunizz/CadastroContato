using CadastroContato.Models;
using System.Collections.Generic;

namespace CadastroContato.Repositorios
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel BuscarPorEmailELogin(string email, string login);
        UsuarioModel ListarId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenha);

        bool Apagar(int id);
    }
}
