using System.Collections.Generic;
using web.Models.Produto;

namespace web.ViewModel.Produto
{
    public class produtoFormViewModel
    {
        public IEnumerable<produtoCategoria> produtoCategorias { get; set; }

        public produto  produto{ get; set; }

        public string titulo
        {
            get
            {
                if (produto != null && produto.produtoID > 0)
                {
                    return "Editar Produto";
                }
                return "Novo Produto";
            }
        }
    }
}