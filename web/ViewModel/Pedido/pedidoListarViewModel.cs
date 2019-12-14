using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using web.Models.Pedido;

namespace web.ViewModel.Pedido
{
    public class pedidoListarViewModel
    {
        public IEnumerable<pedido> pedidos { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dataInicio { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dataFim { get; set; }
    }
}