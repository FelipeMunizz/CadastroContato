using CadastroContato.Models;
using CadastroContato.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace CadastroContato.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarId(id);
            return View(contato);
        }
        public IActionResult DeletarConfirmar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
               bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Cliente Deletado Com Sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possivel deletar o contato";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel deletar o contato, detalhe do errro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Cliente Cadastrado Com Sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel cadastrar o cliente, tente novamente, detalhe do errro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Cliente Alterado com Sucesso";
                    return RedirectToAction("Index");
                }
            }

            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel atualizar o cliente, tente novamente, detalhe do errro:{erro.Message}";
                return RedirectToAction("Index");
            }

            return View("Editar", contato);
        }
    }
}
