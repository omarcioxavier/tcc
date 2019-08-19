using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models.Cliente
{
    [Table("clienteCategoria")]
    public class clienteCategoria
    {
        [Key]
        public int categoriaClienteID { get; set; }

        public string descricao { get; set; }

        public virtual IEnumerable<cliente> clientes { get; set; }
    }
}