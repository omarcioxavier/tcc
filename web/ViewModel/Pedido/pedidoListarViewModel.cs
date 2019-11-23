using System;
using System.Collections.Generic;
using web.Models.Pedido;

namespace web.ViewModel.Pedido
{
    public class pedidoListarViewModel
    {
        public IEnumerable<pedido> pedidos { get; set; }

        public DateTime dataInicio { get; set; }

        public DateTime dataFim { get; set; }
    }
}