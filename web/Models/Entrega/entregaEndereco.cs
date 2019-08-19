using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models.Endereco;

namespace web.Models.Entrega
{
    [Table("entregaEndereco")]
    public class entregaEndereco
    {
        [Key]
        public int entregaEnderecoID { get; set; }

        public int enderecoID { get; set; }

        [ForeignKey("enderecoID ")]
        public virtual endereco endereco { get; set; }
    }
}