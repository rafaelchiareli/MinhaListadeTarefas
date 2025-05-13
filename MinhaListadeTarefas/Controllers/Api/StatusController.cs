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
    public class StatusController : ControllerBase
    {
        private AppDbContext _context;
        private RepositoryStatus _repositoryStatus;

        public StatusController(AppDbContext context)
        {
            _context = context;
            _repositoryStatus = new RepositoryStatus(_context); 
        }

        [HttpGet("ListarStatus")]
        public async Task<IActionResult> Get()
        {
            var listaStatuss = await _repositoryStatus.ListarTodosAsync();
            return Ok(listaStatuss);
        }

        [HttpGet("SelecionarStatus/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Status = await _repositoryStatus.SelecionarChaveAsync(id);
            if (Status == null)
            {
                return NotFound();
            }
            return Ok(Status);
        }

        [HttpPost("CadastrarStatus")]
        public async Task<IActionResult> Post([FromBody] Status Status)
        {
            try
            {
                await _repositoryStatus.IncluirAsync(Status);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("AlterarStatus")]
        public async Task<IActionResult> Put([FromBody] Status Status)
        {
            try
            {
                await _repositoryStatus.AlterarAsync(Status);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("ExcluirStatus/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repositoryStatus.ExcluirAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
