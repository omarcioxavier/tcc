using System.Collections.Generic;
using web.Models.Endereco;

namespace web.ViewModel.Endereco
{
    public class enderecoEditarViewModel
    {
        public endereco endereco { get; set; }

        public IEnumerable<cidade> cidades { get; set; }
        
        public IEnumerable<estado> estados { get; set; }
    }
}