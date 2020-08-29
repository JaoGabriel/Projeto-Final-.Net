using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public ProdutoRepository(ApplicationContext contexto, ICategoriaRepository categoriaRepository) : base(contexto)
        {
            _categoriaRepository = categoriaRepository;
        }


        public IList<Produto> GetProdutos()
        {

            var produto = dbSet
                .Include(p => p.Categoria)
                .ToList();

            return produto;
        }

        public async Task SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {

                await _categoriaRepository.SaveCategoria(livro.Categoria);

                List<Categoria> categorias = new List<Categoria>(_categoriaRepository.GetCategorias());
                var categoria = new Categoria();

                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    for (int i = 0; i < categorias.Count; i++)
                    {
                        if (livro.Categoria == categorias[i].Nome)
                        {
                            categoria = categorias[i];
                        }
                    }
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco, categoria));
                }
            }
            await contexto.SaveChangesAsync();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
    }
}
