using System.Collections.Generic;
using web.Models.Produto;

namespace web.ViewModel.Produto
{
    public class produtoListarViewModel
    {
        public IEnumerable<produto> produtos { get; set; }
        
        public IEnumerable<produtoCategoria> produtoCategorias { get; set; }

        public string descricao { get; set; }

        public int produtoCategoriaID { get; set; }
    }
}