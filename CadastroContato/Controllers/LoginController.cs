using CadastroContato.Helper;
using CadastroContato.Models;
using CadastroContato.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace CadastroContato.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            // Se o Usuario estiver logado, redirecionar para a Home
            if(_sessao.BuscarSessaoDoUsuario()!= null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");
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
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha do usuário é inválida.";
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s).";
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
