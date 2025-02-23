using Microsoft.AspNetCore.Mvc;
using MinhaListadeTarefas.Models;
using System.Data;

namespace MinhaListadeTarefas.Controllers
{
    public class TarefaController : Controller
    {
        public IActionResult Index()
        {
            var lista = new List<Tarefa>();
            lista.Add(new Tarefa()
            {
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddDays(5),
                Id = 1,
                Descricao = "Tarefa 1"

            });
            lista.Add(new Tarefa()
            {
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddDays(5),
                Id = 2,
                Descricao = "Tarefa 2"

            });
            lista.Add(new Tarefa()
            {
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddDays(5),
                Id = 3,
                Descricao = "Tarefa 3"

            });
            lista.Add(new Tarefa()
            {
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddDays(5),
                Id = 4,
                Descricao = "Tarefa 4"

            });

            return View(lista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {

            if (tarefa.DataFim < tarefa.DataInicio)
            {
                ModelState.AddModelError("DataInicio", "A data de fim da tarefa não pode ser menor que a data da início.");
            }
            if (ModelState.IsValid)
            {
                ViewData["Mensagem"] = "Dados salvos com sucesso.";
                ViewBag.Mensgem = "Dados salvos com sucesso.";
                return View(tarefa);
            }
            return View();
        }


        public IActionResult Edit(int id)
        {
            var lista = new List<Tarefa>();
            lista.Add(new Tarefa()
            {
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddDays(5),
                Id = 1,
                Descricao = "Tarefa 1"

            });
            lista.Add(new Tarefa()
            {
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddDays(5),
                Id = 2,
                Descricao = "Tarefa 2"

            });
            lista.Add(new Tarefa()
            {
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddDays(5),
                Id = 3,
                Descricao = "Tarefa 3"

            });
            lista.Add(new Tarefa()
            {
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddDays(5),
                Id = 4,
                Descricao = "Tarefa 4"

            });
            var tarefa = (from p in lista where p.Id == id select p).FirstOrDefault();
            return View(tarefa);
        }

    }
}
