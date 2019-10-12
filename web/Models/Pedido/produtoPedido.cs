using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models.Produto;

namespace web.Models.Pedido
{
    [Table("produtoPedido")]
    public class produtoPedido
    {
        [Key]
        public int produtoPedidoID { get; set; }

        public int quantidade { get; set; }

        public int produtoID { get; set; }
        
        public int pedidoID { get; set; }
        
        [ForeignKey("produtoID")]
        public virtual produto produto { get; set; }

        [ForeignKey("pedidoID")]
        public virtual pedido pedido { get; set; }
    }
}