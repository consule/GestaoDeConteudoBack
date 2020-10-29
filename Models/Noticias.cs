using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeConteudo.Models
{
    public class Noticias
    {
        [Key]
        public int Id { get; set; }
        [MinLength(5, ErrorMessage = "Este item precisa ter um mínimo de 5 caracteres")]
        public string LinkYoutube { get; set; }
        [MinLength(5, ErrorMessage = "Este item precisa ter um mínimo de 5 caracteres")]
        public string Chamada { get; set; }
        [MinLength(5, ErrorMessage = "Este item precisa ter um mínimo de 5 caracteres")]
        public string TextoPrincipal { get; set; }
        public DateTime Publicado { get; set; }
        public bool Ativo { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
