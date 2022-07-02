using CadastroContato.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroContato.Controllers
{
    public class AlterarSenhaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["MensagemSucesso"] = "Senha Alterada com sucesso!";
                    return View("Index", alterarSenhaModel);
                }
                return View("Index", alterarSenhaModel);
            }
            catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Nao conseguimos alterar a senha, tente novamente, detalhe do erro: {erro.Message}";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}
