using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models.Cliente;
using web.Models.Estabelecimento;

namespace web.Models.Categoria
{
    [Table("categoria")]
    public class categoria
    {
        [Key]
        public int categoriaID { get; set; }

        public string descricao { get; set; }

        public virtual IEnumerable<clienteCategoria> clientesCategorias { get; set; }

        public virtual IEnumerable<estabelecimentoCategoria> estabelecimentosCategorias { get; set; }
    }
}