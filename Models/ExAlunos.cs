using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeConteudo.Models
{
    public class ExAlunos
    {
        [Key]
        public int Id { get; set; }
        public string NomeAluno { get; set; }
        public string Ano { get; set; }
        public string Sala { get; set; }
        public string AprovadoEm { get; set; }
        public string Testemunho { get; set; }
  
        public bool Ativo { get; set; }

    }
}
