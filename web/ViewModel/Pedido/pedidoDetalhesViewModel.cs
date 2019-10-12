using System.Collections.Generic;
using web.Models.Cliente;
using web.Models.Pedido;

namespace web.ViewModel.Pedido
{
    public class pedidoDetalhesViewModel
    {
        public pedido pedido { get; set; }

        public cliente cliente { get; set; }

        public IEnumerable<produtoPedido> produtosPedidos { get; set; }

        public string endereco { get; set; }
    }
}