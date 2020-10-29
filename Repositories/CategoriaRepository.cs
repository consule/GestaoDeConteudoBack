using ControleDeConteudo.Data;
using ControleDeConteudo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeConteudo.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DataContext _contexto;
        public CategoriaRepository(DataContext ctx)
        {
            _contexto = ctx;
        }

        public List<Categoria> GetCategoria()
        {
            return _contexto.Categoria.ToList();
        }
        public Categoria GetCategoriaPorID(int id)
        {
            return _contexto.Categoria.Find(id);
        }

        public Categoria PutCategoria(Categoria categoria)
        {
            _contexto.Entry(categoria).State = EntityState.Modified;

            try
            {
                _contexto.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExiste(categoria.Id))
                {
                    return null;
                }
                else
                {
                    return null;
                }
            }
            return categoria;
        }

        public Categoria PostCategoria(Categoria categoria)
        {
            _contexto.Categoria.Add(categoria);
            _contexto.SaveChanges();
            return categoria;
        }

        public Categoria DeleteCategoria(int id)
        {
            var categoria = _contexto.Categoria.Find(id);
            _contexto.Categoria.Remove(categoria);
            _contexto.SaveChanges();
            return categoria;
        }


        public bool CategoriaExiste(int id)
        {
            var x = _contexto.BannerDestaque.Find(id);
            if (x != null)
            {
                return true;
            }
            return false;
        }      
    }
}
