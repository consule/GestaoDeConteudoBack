using ControleDeConteudo.Data;
using ControleDeConteudo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeConteudo.Repositories
{

   
    public class NoticiasRepository : INoticiasRepository
    {
        private readonly DataContext _contexto;
        public NoticiasRepository(DataContext ctx)
        {
            _contexto = ctx;
        }

        public IEnumerable<Noticias> GetNoticias()
        {
            return _contexto.Noticias.Include(x => x.Categoria).ToList();
        }

        public Noticias PostNoticias(Noticias noticias)
        {
            _contexto.Noticias.Add(noticias);
            _contexto.SaveChanges();
            return noticias;
        }

    }
}
