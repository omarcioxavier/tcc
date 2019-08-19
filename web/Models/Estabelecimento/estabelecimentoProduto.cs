using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models.Produto;

namespace web.Models.Estabelecimento
{
    [Table("estabelecimentoProduto")]
    public class estabelecimentoProduto
    {
        [Key]
        public int estabelecimentoProdutoID { get; set; }

        public int estabelecimentoID { get; set; }

        public int produtoID { get; set; }

        [ForeignKey("estabelecimentoID")]
        public virtual estabelecimento estabelecimento { get; set; }

        [ForeignKey("produtoID")]
        public virtual produto produto { get; set; }
    }
}