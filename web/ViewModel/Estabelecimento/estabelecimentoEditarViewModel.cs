using System.Collections.Generic;
using web.Models.Estabelecimento;
using web.Models.Usuario;

namespace web.ViewModel.Estabelecimento
{
    public class estabelecimentoEditarViewModel
    {
        public estabelecimento estabelecimento { get; set; }

        public IEnumerable<estabelecimentoCategoria> estabelecimentoCategorias { get; set; }
    }
}