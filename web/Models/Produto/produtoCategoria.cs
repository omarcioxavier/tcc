using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models.Produto
{
    [Table("produtoCategoria")]
    public class produtoCategoria
    {
        [Key]
        public int produtoCategoriaID { get; set; }

        public string descricao { get; set; }

        public virtual IEnumerable<produto> produtos{ get; set; }
    }
}