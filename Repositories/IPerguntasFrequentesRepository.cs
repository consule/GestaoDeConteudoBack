using ControleDeConteudo.Models;
using System.Collections.Generic;

namespace ControleDeConteudo.Repositories
{
    public interface IPerguntasFrequentesRepository
    {
        IEnumerable<PerguntasFrequentes> GetPerguntasFrequentes();
        PerguntasFrequentes GetPerguntasFrequentesPorID(int id);
        PerguntasFrequentes PutPerguntasFrequentes(PerguntasFrequentes perguntasFrequentes);
        PerguntasFrequentes PostPerguntasFrequentes(PerguntasFrequentes perguntasFrequentes);
        PerguntasFrequentes DeletePerguntasFrequentes(int id);
        bool PerguntaFrequenteExiste(int id);


        //PerguntasFrequentes PerguntaFrequenteExiste(int id);

        //PerguntasFrequentes PutPerguntasFrequentes(int id, PerguntasFrequentes perguntasFrequentes);
    }
}
