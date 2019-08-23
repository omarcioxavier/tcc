using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models.Pedido;

namespace web.Models.Entrega
{
    [Table("entrega")]
    public class entrega
    {
        [Key]
        public int entregaID { get; set; }

        public int pedidoID { get; set; }

        public int entregaEnderecoID { get; set; }

        [ForeignKey("pedidoID")]
        public virtual pedido pedido { get; set; }

        [ForeignKey("entregaEnderecoID")]
        public virtual entregaEndereco entregaEndereco { get; set; }
    }
}