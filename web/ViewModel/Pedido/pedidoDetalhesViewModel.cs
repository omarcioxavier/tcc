using System.Collections.Generic;
using web.Models.Cliente;
using web.Models.Pedido;
using web.Models.Produto;

namespace web.ViewModel.Pedido
{
    public class pedidoDetalhesViewModel
    {
        public pedido pedido { get; set; }

        public cliente cliente { get; set; }

        public IEnumerable<produto> produtos { get; set; }

        public string endereco { get; set; }
    }
}