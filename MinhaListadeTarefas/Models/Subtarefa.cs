using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaListadeTarefas.Models
{
    public class Subtarefa
      
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name= "Descrição")]
        public  string  Descricao { get; set; }

        [Display(Name = "Concluída")]
        public bool Concluida { get; set; } = false;

        public DateTime? DataConclusao { get; set; }

        [ForeignKey("Tarefa")]
        public int TarefaId { get; set; }
        public virtual Tarefa Tarefa { get; set; }

    }

}
