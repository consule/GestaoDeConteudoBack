using ControleDeConteudo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeConteudo.Repositories
{
    public interface INoticiasRepository
    {
        IEnumerable<Noticias> GetNoticias();

        Noticias PostNoticias(Noticias noticias);
    }
}
