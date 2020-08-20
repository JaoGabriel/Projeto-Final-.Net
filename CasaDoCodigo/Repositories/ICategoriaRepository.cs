using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static CasaDoCodigo.Repositories.CategoriaRepository;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Task SaveCategoria(string categoria);
        IList<Categoria> GetCategorias();
    }
}