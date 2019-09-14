using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models.Endereco;

namespace web.Models.Cliente
{
    [Table("clienteEndereco")]
    public class clienteEndereco
    {
        [Key]
        public int clienteEnderecoID { get; set; }

        public int clienteID { get; set; }

        public int enderecoID { get; set; }

        [ForeignKey("clienteID")]
        public virtual cliente cliente { get; set; }

        [ForeignKey("enderecoID")]
        public virtual endereco endereco { get; set; }
    }
}