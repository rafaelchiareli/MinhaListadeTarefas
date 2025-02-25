using System.ComponentModel.DataAnnotations;

namespace MinhaListadeTarefas.Models
{
    public class Categoria
    {
        [Key]
        [Required(ErrorMessage = "O Campo Id é Obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Campo Nome é Obrigatório")]
        [MaxLength(50)]
        public string Nome { get; set; }
    }
}
