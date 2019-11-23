using System.Collections.Generic;
using web.Models.Cliente;

namespace web.ViewModel.Cliente
{
    public class clienteListarViewModel
    {
        public IEnumerable<cliente> clientes { get; set; }

        public string nome { get; set; }

        public string celular { get; set; }

        public bool ativo { get; set; }
    }
}