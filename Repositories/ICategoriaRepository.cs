using ControleDeConteudo.Models;
using System.Collections.Generic;

namespace ControleDeConteudo.Repositories
{
    public interface ICategoriaRepository
    {
        List<Categoria> GetCategoria();
        Categoria GetCategoriaPorID(int id);
        Categoria PutCategoria(Categoria categoria);
        Categoria PostCategoria(Categoria categoria);
        Categoria DeleteCategoria(int id);
        bool CategoriaExiste(int id);
    }
}
