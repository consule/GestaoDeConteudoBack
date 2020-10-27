using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeConteudo.Models
{
    public class DuvidasFrequentes
    {
        [Key]
        public int Id { get; set; }

        [MinLength(5, ErrorMessage = "Este campo requer um mínimo de 5 caracteres!")]
        public string Pergunta { get; set; }

        [MinLength(10, ErrorMessage = "Este campo requer um mínimo de 10 caracteres!")]
        public string Resposta { get; set; }
    }
}
