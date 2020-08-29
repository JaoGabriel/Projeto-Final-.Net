using System.Collections.Generic;

namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaProdutoViewModel
    {
        public BuscaProdutoViewModel(IList<Produto> produtos)
        {
            Produtos = produtos;
        }

        public IList<Produto> Produtos { get; set; }
        public string Pesquisa { get; set; }
    }
}

