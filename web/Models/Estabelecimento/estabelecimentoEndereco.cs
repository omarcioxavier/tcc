using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models.Endereco;

namespace web.Models.Estabelecimento
{
    [Table("estabelecimentoEndereco")]
    public class estabelecimentoEndereco
    {
        [Key]
        public int estabelecimentoEnderecoID { get; set; }

        public int estabelecimentoID { get; set; }

        public int enderecoID { get; set; }

        [ForeignKey("estabelecimentoID")]
        public virtual estabelecimento estabelecimento { get; set; }

        [ForeignKey("enderecoID")]
        public virtual endereco endereco { get; set; }
    }
}