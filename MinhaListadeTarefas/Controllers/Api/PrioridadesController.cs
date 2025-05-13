using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaListadeTarefas.Models;
using MinhaListadeTarefas.Repositories;

namespace MinhaListadeTarefas.Controllers.Api
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadesController : ControllerBase
    {

        private AppDbContext _context;
        private RepositoryPrioridade _repositoryPrioridade;

        public PrioridadesController(AppDbContext context)
        {
            _context = context;
            _repositoryPrioridade = new RepositoryPrioridade(_context);
        }

        [HttpGet("ListarPrioridades")]
        public async Task<IActionResult> Get()
        {
            var listaPrioridades = await _repositoryPrioridade.ListarTodosAsync();
            return Ok(listaPrioridades);
        }

        [HttpGet("SelecionarPrioridade/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var prioridade = await _repositoryPrioridade.SelecionarChaveAsync(id);
            if (prioridade == null)
            {
                return NotFound();
            }
            return Ok(prioridade);
        }

        [HttpPost("CadastrarPriodidade")]
        public async Task<IActionResult> Post([FromBody] Prioridade prioridade)
        {
            try
            {
                await _repositoryPrioridade.IncluirAsync(prioridade);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("AlterarPrioridade")]
        public async Task<IActionResult> Put([FromBody] Prioridade prioridade)
        {
            try
            {
                await _repositoryPrioridade.AlterarAsync(prioridade);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("ExcluirPrioridade/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repositoryPrioridade.ExcluirAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
