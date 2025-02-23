

using System.ComponentModel.DataAnnotations;

namespace MinhaListadeTarefas.Models
{
    public class Tarefa
    {
        [Required(ErrorMessage = "O Campo Id é Obrigatório")]
        [Display(Name = "Id  da Tarefa")]
        [Range(0, int.MaxValue, ErrorMessage = "Insira um valor válido")]

        public int? Id { get; set; }


        [Required(ErrorMessage = "O Campo Descrição é Obrigatório")]
        [Display(Name = "Descrição da Tarefa")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "O Campo Data de Início  é Obrigatório")]
        [Display(Name = "Data de Início da Tarefa")]
        [DataType(DataType.Date)]
        public DateTime? DataInicio { get; set; }

        [Display(Name = "Data de Fim da Tarefa")]
        public DateTime? DataFim { get; set; }
    }
}
