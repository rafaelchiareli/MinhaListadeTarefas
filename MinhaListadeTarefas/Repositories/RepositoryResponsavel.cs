﻿using MinhaListadeTarefas.Models;

namespace MinhaListadeTarefas.Repositories
{
    public class RepositoryResponsavel: RepositoryBase<Responsavel>
    {
        public RepositoryResponsavel(AppDbContext contexto, bool saveChanges = true) : base(contexto, saveChanges)
        {
        }
    }
}
