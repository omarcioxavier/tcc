using System;
using System.Collections.Generic;
using web.Models.Pedido;

namespace web.ViewModel.Pedido
{
    public class pedidoListarViewModel
    {
        public IEnumerable<pedido> pedidos { get; set; }

        public string dataInicio { get; set; }

        public string dataFim { get; set; }
    }
}