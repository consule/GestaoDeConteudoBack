using ControleDeConteudo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeConteudo.Repositories
{
    public interface IExAlunosRepository
    {
        IEnumerable<ExAlunos> GetExAlunos();
        ExAlunos GetExAlunosPorID(int id);
        ExAlunos PutExAlunos(ExAlunos exAluno);
        ExAlunos PostExAlunos(ExAlunos exAluno);
        ExAlunos DeleteExAlunos(int id);
        bool ExAlunosExiste(int id);
    }
}
