﻿using Microsoft.EntityFrameworkCore;
using MinhaListadeTarefas.Interfaces;
using MinhaListadeTarefas.Models;

namespace MinhaListadeTarefas.Repositories
{
    public class RepositoryTarefa: RepositoryBase<Tarefa> 
    {
        public RepositoryTarefa(AppDbContext contexto, bool saveChanges = true) : base(contexto, saveChanges)
        {
            
        }       

        public List<Tarefa> PesquisarTarefa(string termo)
        {
            return contexto.Tarefas.Where(x => x.Descricao.Contains(termo)).ToList();
        }
    }
}
