using ControleDeConteudo.Models;
using System.Collections.Generic;

namespace ControleDeConteudo.Repositories
{
    public interface IDuvidasFrequentesRepository
    {
        IEnumerable<DuvidasFrequentes> GetDuvidasFrequentes();
        DuvidasFrequentes GetDuvidasFrequentesPorID(int id);
        DuvidasFrequentes PutDuvidasFrequentes(DuvidasFrequentes duvidasFrequentes);
        DuvidasFrequentes PostDuvidasFrequentes(DuvidasFrequentes duvidasFrequentes);
        DuvidasFrequentes DeleteDuvidasFrequentes(int id);
        bool DuvidaFrequenteExiste(int id);


        //PerguntasFrequentes PerguntaFrequenteExiste(int id);

        //PerguntasFrequentes PutPerguntasFrequentes(int id, PerguntasFrequentes perguntasFrequentes);
    }
}
