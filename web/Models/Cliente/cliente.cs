using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models.Pedido;

namespace web.Models.Cliente
{
    [Table("cliente")]
    public class cliente
    {
        [Key]
        public int clienteID { get; set; }

        public string nome { get; set; }

        public string email { get; set; }

        public string numeroCelular { get; set; }

        public bool ativo { get; set; }

        public int cllienteCategoriaID { get; set; }

        [ForeignKey("cllienteCategoriaID")]
        public virtual clienteCategoria clienteCategoria{ get; set; }

        public virtual IEnumerable<pedido> pedidos{ get; set; }
    }
}