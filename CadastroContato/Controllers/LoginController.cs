using CadastroContato.Models;
using CadastroContato.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace CadastroContato.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if(usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha Invalida";
                    }
                    TempData["MensagemErro"] = $"Usuario Invalido";
                }
                return View("Index");
            }
            
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel realizar o login, tente novamente, detalhe do errro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
