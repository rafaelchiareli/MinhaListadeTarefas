using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaListadeTarefas.Models;
using MinhaListadeTarefas.Repositories;

namespace MinhaListadeTarefas.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {

        private AppDbContext _context;
        private RepositoryTarefa _repositoryTarefa;

        public TarefasController(AppDbContext context)
        {
            _context = context;
            _repositoryTarefa = new RepositoryTarefa(_context);
        }

        [HttpGet("ListarTarefas")]
        public async Task<IActionResult> Get()
        {
            var listaTarefas = await _repositoryTarefa.ListarTodosAsync();
            return Ok(listaTarefas);
        }


        [HttpGet("SelecionarTarefa/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tarefa = await _repositoryTarefa.SelecionarChaveAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpPost("CadastrarTarefa")]
        public async Task<IActionResult> Post([FromBody] Tarefa tarefa)
        {
            try
            {
                await _repositoryTarefa.IncluirAsync(tarefa);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
