using System.ComponentModel.DataAnnotations;

namespace ControleDeConteudo.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [MinLength(5, ErrorMessage = "Este item precisa ter um mínimo de 5 caracteres")]
        public string Descricao { get; set; }
         
    }
}
