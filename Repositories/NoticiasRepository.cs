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

        public Noticias GetNoticiaPorID(int id)
        {
            return _contexto.Noticias.Find(id);
        }

        public Noticias PostNoticias(Noticias noticias)
        {
            _contexto.Noticias.Add(noticias);
            _contexto.SaveChanges();
            return noticias;
        }

        public Noticias PutNoticia(Noticias noticia)
        {
            _contexto.Entry(noticia).State = EntityState.Modified;
            try
            {
                _contexto.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticiaExiste(noticia.Id))
                {
                    return null;
                } else
                {
                    return null;
                }
            }
            return noticia;
        }

        public Noticias DeleteNoticia(int id)
        {
            var noticia = _contexto.Noticias.Find(id);
            _contexto.Noticias.Remove(noticia);
            _contexto.SaveChanges();
            return noticia;
        }

        public bool NoticiaExiste(int id)
        {
            var x = _contexto.Noticias.Find(id);
            if (x != null)
            {
                return true;
            }
            return false;
        }

       

    }
}
