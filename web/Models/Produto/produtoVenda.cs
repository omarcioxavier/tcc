using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models.Cliente;

namespace web.Models.Produto
{
    [Table("produtoVenda")]
    public class produtoVenda
    {
        [Key]
        public int produtoVendaID { get; set; }

        public virtual IEnumerable<produto> produto { get; set; }

        public virtual IEnumerable<clienteVenda> clienteVendas { get; set; }
    }
}