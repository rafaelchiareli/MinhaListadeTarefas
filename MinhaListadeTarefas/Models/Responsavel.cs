﻿using System.ComponentModel.DataAnnotations;

namespace MinhaListadeTarefas.Models
{
    public class Responsavel
    {
        [Key]
        [Required(ErrorMessage = "O Campo Id é Obrigatório")]
        public int Id { get; set; }


        [Required(ErrorMessage = "O Campo Nome é Obrigatório")]
        [MaxLength(200)]
        public string Nome { get; set; }    
    }
}
