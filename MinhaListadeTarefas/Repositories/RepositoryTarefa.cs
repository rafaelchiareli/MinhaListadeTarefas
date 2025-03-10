using Microsoft.EntityFrameworkCore;
using MinhaListadeTarefas.Interfaces;
using MinhaListadeTarefas.Models;

namespace MinhaListadeTarefas.Repositories
{
    public class RepositoryTarefa: RepositoryBase<Tarefa> 
    {
        public RepositoryTarefa(AppDbContext contexto, bool saveChanges = true) : base(contexto, saveChanges)
        {
            
        }

        public async Task<Tarefa> SelecionarTarefaTeste(int idResponsavel)
            {
            return await contexto.Tarefas.FirstOrDefaultAsync(x => x.ResponsavelId == idResponsavel);
        }
    }
}
