using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MinhaListadeTarefas.Models;

namespace MinhaListadeTarefas.Controllers
{
    public class UserRoleController : DefaultController
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager;

        public UserRoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public void CarregaViewBag()
        {
            ViewBag.ListaRoles = _roleManager.Roles.ToList();
            ViewBag.ListaUsuarios = _userManager.Users.ToList();
        }

        public IActionResult Create()
        {
            CarregaViewBag();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserRoles userRoles)
        {
            var user = await _userManager.FindByIdAsync(userRoles.UserId);
            if (user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, userRoles.RoleName);
                if (result.Succeeded)
                {
                    ViewData["Mensagem"] = "Role atribuída com sucesso!";
                }
                else
                {
                    ViewData["MensagemErro"] = "Erro ao atribuir a role!" + result.Errors;
                }
            }
            CarregaViewBag();
            return View();
        }
    }
}
