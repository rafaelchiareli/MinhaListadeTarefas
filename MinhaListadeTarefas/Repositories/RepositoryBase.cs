using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MinhaListadeTarefas.Interfaces;
using MinhaListadeTarefas.Models;

namespace MinhaListadeTarefas.Repositories
{
    public class RepositoryBase<T> : IRepository<T>, IDisposable where T : class

    {

        public AppDbContext context;
        public bool _saveChanges = true;
        public RepositoryBase(AppDbContext dataContext, bool saveChanges)
        {
            context = dataContext;
            _saveChanges = saveChanges;
        }

        public void Alterar(T entity)
        {
         context.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            if (_saveChanges)
            {
                context.SaveChanges();
            }
        }

        public async Task<T> AlterarAsync(T entity)
        {
            context.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            if (_saveChanges)
            {
                await context.SaveChangesAsync();
               
            }
            return entity;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Excluir(T entity)
        {
            context.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            if (_saveChanges)
            {
                context.SaveChanges();
            }
        }

        public async Task ExcluirAsync(T entity)
        {
            context.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            if (_saveChanges)
            {
                await  context.SaveChangesAsync();
            }
            
        }

        public void Incluir(T entity)
        {
           context.Set<T>().Add(entity);
            if (_saveChanges)
            {
                context.SaveChanges();
            }
        }

        public async Task<T> IncluirAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            if (_saveChanges)
            {
                 await context.SaveChangesAsync();
            }
            return entity;
        }

        public T Selecionar(params object[] variavel)
        {
           return context.Set<T>().Find(variavel);  
        }

        public async  Task<T> SelecionarAsync(params object[] variavel)
        {
              return await context.Set<T>().FindAsync(variavel);
        }

        public List<T> SelecionarTodos()
        {
            return context.Set<T>().ToList();
        }

        public async Task<List<T>> SelecionarTodosAsync()
        {
            return await context.Set<T>().ToListAsync();
        }
    }
}