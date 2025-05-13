using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaListadeTarefas.Models;
using MinhaListadeTarefas.Repositories;
using System.Security.Cryptography.X509Certificates;

namespace MinhaListadeTarefas.Controllers.Api
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private RepositoryCategoria _repositoryCategoria;
        private AppDbContext   _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
            _repositoryCategoria = new RepositoryCategoria(_context);
        }

        [HttpGet("ListarCategorias")]
        public async Task<IActionResult> Get()
        {
            var listaCategotegorias = await _repositoryCategoria.ListarTodosAsync();
            return Ok(listaCategotegorias);
        }

        [HttpGet("SelecionarCategoria/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var categoria = await _repositoryCategoria.SelecionarChaveAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost("CadastrarCategoria")]
        public async Task<IActionResult> Post([FromBody]Categoria categoria)
        {
            try
            {
                await _repositoryCategoria.IncluirAsync(categoria);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("AlterarCategoria")]
        public async Task<IActionResult> Put([FromBody]Categoria categoria)
        {
            try
            {
                await _repositoryCategoria.AlterarAsync(categoria);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("ExcluirCategoria/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repositoryCategoria.ExcluirAsync(id);
                return Ok();
            }
            catch( Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
