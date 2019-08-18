using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models.Estabelecimento
{
    [Table("estabelecimentoProduto")]
    public class estabelecimentoProduto
    {
        [Key]
        public int estabelecimentoProdutoID { get; set; }
    }
}