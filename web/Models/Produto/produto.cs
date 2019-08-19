using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models.Estabelecimento;
using web.Models.Pedido;

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

        public int produtoCategoriaID { get; set; }

        [ForeignKey("produtoCategoriaID")]
        public virtual produtoCategoria produtoCategoria { get; set; }

        public virtual IEnumerable<produtoPedido> produtosPedidos { get; set; }
        
        public virtual IEnumerable<estabelecimentoProduto> estabelecimentosProdutos { get; set; }
        
    }
}