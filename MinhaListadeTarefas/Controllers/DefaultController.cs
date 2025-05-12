using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MinhaListadeTarefas.Controllers
{
    [Authorize]
    public class DefaultController : Controller
    {
        public IActionResult teste()
        {
            return View();
        }
    }
}
