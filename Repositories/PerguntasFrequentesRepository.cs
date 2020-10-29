using ControleDeConteudo.Data;
using ControleDeConteudo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleDeConteudo.Data;
using ControleDeConteudo.Models;

namespace ControleDeConteudo.Repositories
{
    public class PerguntasFrequentesRepository : IPerguntasFrequentesRepository
    {
        private readonly DataContext _contexto;
        public PerguntasFrequentesRepository(DataContext ctx)
        {
            _contexto = ctx;
        }

        public IEnumerable<PerguntasFrequentes> GetPerguntasFrequentes()
        {            
            return _contexto.PerguntasFrequentes.ToList();
        }

        public PerguntasFrequentes GetPerguntasFrequentesPorID(int id)
        {
            return _contexto.PerguntasFrequentes.Find(id);
        }

        public PerguntasFrequentes PutPerguntasFrequentes(PerguntasFrequentes perguntasFrequentes)
        {        
            _contexto.Entry(perguntasFrequentes).State = EntityState.Modified;
    
            try
            {
                _contexto.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerguntaFrequenteExiste(perguntasFrequentes.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return  perguntasFrequentes;
        }

        public PerguntasFrequentes PostPerguntasFrequentes(PerguntasFrequentes perguntasFrequentes)
        {

            //var pf = _contexto.PerguntasFrequentes.Add(perguntasFrequentes);
            _contexto.PerguntasFrequentes.Add(perguntasFrequentes);
            _contexto.SaveChanges();
            return perguntasFrequentes;
        }

        public PerguntasFrequentes DeletePerguntasFrequentes(int id)
        {
            var perguntasFrequentes =  _contexto.PerguntasFrequentes.Find(id);
            _contexto.PerguntasFrequentes.Remove(perguntasFrequentes);
            _contexto.SaveChanges();
            return perguntasFrequentes;
        }
       

        public  bool PerguntaFrequenteExiste(int id)
        {
            var x = _contexto.PerguntasFrequentes.Find(id);
            if (x != null)
            {
                return true;
            }
            return false;
        }
    }
}
