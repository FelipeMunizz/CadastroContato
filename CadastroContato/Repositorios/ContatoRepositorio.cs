using CadastroContato.Data;
using CadastroContato.Models;

namespace CadastroContato.Repositorios
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly ContatoContext _contatoContext;
        public ContatoRepositorio(ContatoContext contatoContext)
        {
            _contatoContext = contatoContext;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _contatoContext.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            //gravar no banco
            contato.DataCadastro = DateTime.Now;
            _contatoContext.Contatos.Add(contato);
            _contatoContext.SaveChanges();
            return contato;
        }

        public ContatoModel ListarId(int id)
        {
            return _contatoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarId(contato.Id);
            if (contatoDb == null) throw new Exception("Houve um erro na atualização do cliente");
            {
                contatoDb.Nome = contato.Nome;
                contatoDb.Email = contato.Email;
                contatoDb.Celular = contato.Celular;
                contatoDb.Servico = contato.Servico;
                contatoDb.Status = contato.Status;
                contatoDb.DataAtualizacao = DateTime.Now;

                _contatoContext.Contatos.Update(contatoDb);
                _contatoContext.SaveChanges();

                return contatoDb;
            }            
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDb = ListarId(id);
            if (contatoDb == null) throw new Exception("Houve um erro na Exclusão do cliente");
            _contatoContext.Contatos.Remove(contatoDb);
            _contatoContext.SaveChanges();
            return true;
        }
    }
}
