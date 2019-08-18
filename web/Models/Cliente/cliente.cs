using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models.Cliente
{
    [Table("cliente")]
    public class cliente
    {
        [Key]
        public int clienteID { get; set; }

        public string nome { get; set; }

        public string email { get; set; }

        public bool ativo { get; set; }

        public virtual IEnumerable<clienteVenda> clientesVendas { get; set; }
    }
}