using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public virtual int pedido { get; set; }

        [ForeignKey("entregaEnderecoID")]
        public virtual int entregaEndereco { get; set; }
    }
}