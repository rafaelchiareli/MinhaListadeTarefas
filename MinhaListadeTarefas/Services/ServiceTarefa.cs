﻿using MinhaListadeTarefas.Models;
using MinhaListadeTarefas.Repositories;

namespace MinhaListadeTarefas.Services
{
    public class ServiceTarefa
    {

        private AppDbContext _context;
        public RepositoryTarefa RptTarefa { get; set; }
        public RepositoryCategoria RptCategoria { get; set; }
        public RepositoryPrioridade RptProridade { get; set; }
        public RepositoryResponsavel RptResponsavel { get; set; }
        public RepositoryStatus RptStatus { get; set; }


        public ServiceTarefa(AppDbContext context)
        {
            _context = context;
            RptTarefa = new RepositoryTarefa(_context);
            RptCategoria = new RepositoryCategoria(_context);
            RptProridade = new RepositoryPrioridade(_context);
            RptResponsavel = new RepositoryResponsavel(_context);
            RptStatus = new RepositoryStatus(_context);
        }

   




    }
}
