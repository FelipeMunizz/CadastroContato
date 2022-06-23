using CadastroContato.Models;

namespace CadastroContato.Repositorios
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);
    }
}
