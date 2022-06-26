using CadastroContato.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CadastroContato.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
