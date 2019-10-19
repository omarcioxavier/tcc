using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models.Endereco;
using web.Models.Pedido;

namespace web.Models.Entrega
{
    [Table("entrega")]
    public class entrega
    {
        [Key]
        public int entregaID { get; set; }

        public int pedidoID { get; set; }

        public int enderecoID { get; set; }

        [ForeignKey("pedidoID")]
        public virtual pedido pedido { get; set; }

        [ForeignKey("enderecoID")]
        public virtual endereco endereco { get; set; }
    }
}