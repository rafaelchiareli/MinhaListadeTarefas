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
    public class ResponsavelController : ControllerBase
    {
        private AppDbContext _context;
        private RepositoryResponsavel _repositoryResponsavel;

        public ResponsavelController(AppDbContext context)
        {
            _context = context;
           _repositoryResponsavel = new RepositoryResponsavel(_context);
        }

        [HttpGet("ListarResponsavel")]
        public async Task<IActionResult> Get()
        {
            var listaResponsavels = await _repositoryResponsavel.ListarTodosAsync();
            return Ok(listaResponsavels);
        }

        [HttpGet("SelecionarResponsavel/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Responsavel = await _repositoryResponsavel.SelecionarChaveAsync(id);
            if (Responsavel == null)
            {
                return NotFound();
            }
            return Ok(Responsavel);
        }

        [HttpPost("CadastrarResponsavel")]
        public async Task<IActionResult> Post([FromBody] Responsavel Responsavel)
        {
            try
            {
                await _repositoryResponsavel.IncluirAsync(Responsavel);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("AlterarResponsavel")]
        public async Task<IActionResult> Put([FromBody] Responsavel Responsavel)
        {
            try
            {
                await _repositoryResponsavel.AlterarAsync(Responsavel);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("ExcluirResponsavel/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repositoryResponsavel.ExcluirAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
