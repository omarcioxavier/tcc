using System.Collections.Generic;

namespace web.ModelsResponse
{
    public class estabelecimentoResponse
    {
        public int id { get; set; }

        public string name { get; set; }

        public IEnumerable<itensResponse> itens { get; set; }

        public IEnumerable<drinksResponse> drinks { get; set; }
    }
}