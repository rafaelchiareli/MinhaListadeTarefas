using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using MinhaListadeTarefas.Models;
using System.ComponentModel.DataAnnotations;

namespace MinhaListadeTarefas.ViewModels
{
    public class TarefaVM
    {
        public int? Id { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Data prevista de fim")]
        public DateTime DataInicio { get; set; }
        [Display(Name = "Data de Conslusão")]
        public DateTime? DataConclusao { get; set; }
        public string? Categoria { get; set; }
        public string? Prioridade { get; set; }
        [Display(Name = "Responsável")]
        public string? Responsavel { get; set; }
        public string? Status { get; set; }

        public int CodigoCategoria { get; set; }
        public int CodigoResponsavel { get; set; }
        public int CodigoStatus { get; set; }
        public int CodigoPrioridade { get; set; }

        public  string Observacoes { get; set; }
        public List<Subtarefa> ListaSubtarefas { get; set; }
        public TarefaVM()
        {
                
        }

        public static  List<TarefaVM> ListarTarefasAsync(string termo)
        {
            var db = new AppDbContext();
            var listaTarefas =  db.Tarefas.Where( x=> x.Descricao.Contains(termo)).ToList();
            var listaRetorno = new List<TarefaVM>();
            foreach (var item in listaTarefas)
            {
                listaRetorno.Add(new TarefaVM()
                {
                    Categoria = db.Categorias.FirstOrDefault(x => x.Id == item.CategoriaId).Nome ,
                    DataConclusao = item.DataFim,
                    DataInicio = (DateTime)item.DataInicio,
                    Prioridade = db.Prioridades.FirstOrDefault(x => x.Id == item.PrioridadeId).Nome,
                    Responsavel = db.Responsaveis.FirstOrDefault(x => x.Id == item.ResponsavelId).Nome,
                    Status = db.Status.FirstOrDefault(x => x.Id == item.StatusId).Nome,
                    Id = item.Id,

                });
            }
            return listaRetorno;
        }
    }
}
