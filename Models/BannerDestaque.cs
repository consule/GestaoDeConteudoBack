﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeConteudo.Models
{
    public class BannerDestaque
    {
        [Key]
        public int Id { get; set; }
        [MinLength(5, ErrorMessage = "Este item precisa ter um mínimo de 5 caracteres")]
        public string Titulo { get; set; }
        [MinLength(5, ErrorMessage = "Este item precisa ter um mínimo de 5 caracteres")]
        public string Chamada { get; set; }
        [MinLength(5, ErrorMessage = "Este item precisa ter um mínimo de 5 caracteres")]
        public string Link { get; set; }

        public bool Ativo { get; set; }

    }
}