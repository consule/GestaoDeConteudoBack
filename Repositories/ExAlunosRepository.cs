using ControleDeConteudo.Data;
using ControleDeConteudo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeConteudo.Repositories
{
    public class ExAlunosRepository : IExAlunosRepository
    {
        private readonly DataContext _contexto;
        public ExAlunosRepository(DataContext ctx)
        {
            _contexto = ctx;
        }

        public IEnumerable<ExAlunos> GetExAlunos()
        {
            return _contexto.ExAlunos.ToList();
        }


        public ExAlunos GetExAlunosPorID(int id)
        {
            return _contexto.ExAlunos.Find(id);
        }

        public ExAlunos PutExAlunos(ExAlunos exAluno)
        {
            _contexto.Entry(exAluno).State = EntityState.Modified;

            try
            {
                _contexto.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExAlunosExiste(exAluno.Id))
                {
                    return null;
                }
                else
                {
                    return null;
                }
            }
            return exAluno;
        }

        public ExAlunos PostExAlunos(ExAlunos exAluno)
        {

            //var pf = _contexto.ExAlunos.Add(exAluno);
            _contexto.ExAlunos.Add(exAluno);
            _contexto.SaveChanges();
            return exAluno;
        }

        public ExAlunos DeleteExAlunos(int id)
        {
            var exAluno = _contexto.ExAlunos.Find(id);
            _contexto.ExAlunos.Remove(exAluno);
            _contexto.SaveChanges();
            return exAluno;
        }


        public bool ExAlunosExiste(int id)
        {
            var x = _contexto.ExAlunos.Find(id);
            if (x != null)
            {
                return true;
            }
            return false;
        }
    }
}
