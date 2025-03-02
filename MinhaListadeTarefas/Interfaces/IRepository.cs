using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MinhaListadeTarefas.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> IncluirAsync(T entity);
        void Incluir(T entity);
        Task<T> AlterarAsync(T entity);
        void Alterar(T entity);

        Task ExcluirAsync(T entity);
        void Excluir(T entity);     
        
        Task<List<T>> SelecionarTodosAsync();
        List<T> SelecionarTodos();
        Task<T> SelecionarAsync(params object[] variavel);
        T Selecionar(params object[] variavel);



    }
}