using ControleDeConteudo.Data;
using ControleDeConteudo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ControleDeConteudo.Repositories
{
    public class DuvidasFrequentesRepository : IDuvidasFrequentesRepository
    {
        private readonly DataContext _contexto;
        public DuvidasFrequentesRepository(DataContext ctx)
        {
            _contexto = ctx;
        }

        public IEnumerable<DuvidasFrequentes> GetDuvidasFrequentes()
        {            
            return _contexto.DuvidasFrequentes.ToList();
        }

        public DuvidasFrequentes GetDuvidasFrequentesPorID(int id)
        {
            return _contexto.DuvidasFrequentes.Find(id);
        }

        public DuvidasFrequentes PutDuvidasFrequentes(DuvidasFrequentes duvidasFrequentes)
        {        
            _contexto.Entry(duvidasFrequentes).State = EntityState.Modified;
    
            try
            {
                _contexto.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DuvidaFrequenteExiste(duvidasFrequentes.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return duvidasFrequentes;
        }

        public DuvidasFrequentes PostDuvidasFrequentes(DuvidasFrequentes duvidasFrequentes)
        {

            _contexto.DuvidasFrequentes.Add(duvidasFrequentes);
            _contexto.SaveChanges();
            return duvidasFrequentes;
        }

        public DuvidasFrequentes DeleteDuvidasFrequentes(int id)
        {
            var duvidasFrequentes =  _contexto.DuvidasFrequentes.Find(id);
            _contexto.DuvidasFrequentes.Remove(duvidasFrequentes);
            _contexto.SaveChanges();
            return duvidasFrequentes;
        }
       

        public  bool DuvidaFrequenteExiste(int id)
        {
            var x = _contexto.DuvidasFrequentes.Find(id);
            if (x != null)
            {
                return true;
            }
            return false;
        }
    }
}
