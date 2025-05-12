using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MinhaListadeTarefas.Models;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace MinhaListadeTarefas.Controllers
{
    public class RolesController : DefaultController
    {

        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var listaRoles = new List<IdentityRole>(); 
            listaRoles = _roleManager.Roles.ToList();
            return View(listaRoles);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(Role role)
        {
            var identityRole = new IdentityRole(role.RoleName);
            var result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                ViewData["Mensagem"] = "Role criada com sucesso!";
            }
            else
            {
                ViewData["MensagemErro"] = "Erro ao criar a role!";
            }
            return View();
        }
        
    }
}
