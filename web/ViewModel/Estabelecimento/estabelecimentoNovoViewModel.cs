using System.Collections.Generic;
using web.Models.Estabelecimento;
using web.Models.Usuario;

namespace web.ViewModel.Estabelecimento
{
    public class estabelecimentoNovoViewModel
    {
        public estabelecimento estabelecimento { get; set; }

        public usuario usuario { get; set; }

        public IEnumerable<estabelecimentoCategoria> estabelecimentoCategorias { get; set; }
    }
}