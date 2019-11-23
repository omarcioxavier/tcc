using System.Collections.Generic;
using web.Models.Usuario;

namespace web.ViewModel.Usuario
{
    public class usuarioListarViewModel
    {
        public IEnumerable<usuario> usuarios { get; set; }

        public string login { get; set; }

        public bool ativo { get; set; }
    }
}