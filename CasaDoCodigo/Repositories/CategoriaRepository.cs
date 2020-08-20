using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {

        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Categoria> GetCategorias()
        {
            return dbSet.ToList();
        }

        public async Task SaveCategoria(string categoria)
        {

            if (!dbSet.Where(p => p.Nome == categoria).Any())
            {
                dbSet.Add(new Categoria(categoria));
            }

            await contexto.SaveChangesAsync();
        }
    }
}
