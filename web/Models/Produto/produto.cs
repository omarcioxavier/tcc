using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models.Produto
{
    [Table("produto")]
    public class produto
    {
        [Key]
        public int produtoID { get; set; }
        
        public string descricao { get; set; }

        public float precoUnitario { get; set; }

        public bool ativo { get; set; }
    }
}