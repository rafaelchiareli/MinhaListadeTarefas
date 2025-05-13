using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MinhaListadeTarefas.Helpers;
using MinhaListadeTarefas.Models;
using MinhaListadeTarefas.Services;
using MinhaListadeTarefas.ViewModels;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MinhaListadeTarefas.Controllers
{
    public class TarefaController : DefaultController
    {

        private AppDbContext _context;
        private ServiceTarefa _serviceTarefa;
        private UserManager<IdentityUser> _userManager;
        public TarefaController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _serviceTarefa = new ServiceTarefa(_context);
        }

        public async Task CarregarCombos()
        {
            ViewData["Categorias"] = new SelectList(await _serviceTarefa.RptCategoria.ListarTodosAsync(), "Id", "Nome");
            ViewData["Prioridades"] = new SelectList(await _serviceTarefa.RptProridade.ListarTodosAsync(), "Id", "Nome");
            ViewData["Responsaveis"] = new SelectList(await _serviceTarefa.RptResponsavel.ListarTodosAsync(), "Id", "Nome");
            ViewData["Status"] = new SelectList(await _serviceTarefa.RptStatus.ListarTodosAsync(), "Id", "Nome");
        }

        public async Task<IActionResult> Index()
        {
            var listaTarefas = await _serviceTarefa.RptTarefa.ListarTodosAsync();
            return View(listaTarefas);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {


            await CarregarCombos();
            return View();
        }

        public  IActionResult IndexPaginado(int pageNumber =1, int pageSize = 2)
        {
          var listaTarefas =  _serviceTarefa.RptTarefa.ListarTodos().AsQueryable();
            var paginatedList =  PaginatedList<Tarefa>.CreateAsync(listaTarefas, pageNumber, pageSize);
            return View(paginatedList);
        }



       public IActionResult Consultar()
        {
            return View();  
        }
        public IActionResult Pesquisar(string termo)
        {
            var listaTarefas = TarefaVM.ListarTarefasAsync(termo);
            return PartialView("_Pesquisa", listaTarefas);

             
        }

        [HttpPost]
        public async Task<IActionResult> Create(TarefaVM tarefa)
        {
            await CarregarCombos();
            var user = _userManager.GetUserAsync(User);
            if (tarefa.DataConclusao < tarefa.DataInicio)
            {
                ModelState.AddModelError("DataInicio", "A data de fim da tarefa não pode ser menor que a data da início.");
            }
            var teste = Request.Form["txtTeste"];
            if (ModelState.IsValid)
            {
                ViewData["Mensagem"] = "Dados salvos com sucesso.";
                await _serviceTarefa.IncluirTarefaAsync(tarefa);
                return View(tarefa);
            }
            return View();
        }


        public async Task<IActionResult> Edit(int id)
        {
            await CarregarCombos();
            var tarefa = await _serviceTarefa.RptTarefa.SelecionarChaveAsync(id);
            return View(tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Tarefa tarefa)
        {
            await CarregarCombos();
            if (tarefa.DataFim < tarefa.DataInicio)
            {
                ModelState.AddModelError("DataInicio", "A data de fim da tarefa não pode ser menor que a data da início.");
            }
            if (ModelState.IsValid)
            {
                ViewData["Mensagem"] = "Dados salvos com sucesso.";
                await _serviceTarefa.RptTarefa.AlterarAsync(tarefa);
                return View(tarefa);
            }
            return View();

        }

    }
}
