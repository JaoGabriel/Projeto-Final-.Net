using System.Collections.Generic;

namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaProdutoViewModel
    {
        public BuscaProdutoViewModel(IList<Produto> produtos, bool resultado)
        {
            Produtos = produtos;
            Resultado = resultado;
        }
        public BuscaProdutoViewModel(bool resultado)
        {
            Resultado = resultado;
        }
        public IList<Produto> Produtos { get; set; }
        public string Pesquisa { get; set; }
        public bool Resultado { get; set; }
    }
}

