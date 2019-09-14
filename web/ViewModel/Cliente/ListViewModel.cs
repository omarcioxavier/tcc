using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.Models.Cliente;

namespace web.ViewModel.Cliente
{
    public class ListViewModel
    {
        public IEnumerable<cliente> clientes{ get; set; }

        public cliente cliente { get; set; }
    }
}