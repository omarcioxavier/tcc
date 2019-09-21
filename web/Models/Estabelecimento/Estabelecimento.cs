using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models.Pedido;
using web.Models.Usuario;

namespace web.Models.Estabelecimento
{
    [Table("estabelecimento")]
    public class estabelecimento
    {
        [Key]
        public int estabelecimentoID { get; set; }

        public string razaoSocial { get; set; }

        public string nomeFantasia { get; set; }

        public string cnpj { get; set; }

        public string inscricaoEstadual { get; set; }

        public bool ativo { get; set; }

        public int estabelecimentoCategoriaID { get; set; }

        [ForeignKey("estabelecimentoCategoriaID")]
        public virtual estabelecimentoCategoria estabelecimentoCategoria { get; set; }

        public virtual IEnumerable<pedido> pedidos{ get; set; }

        public virtual IEnumerable<estabelecimentoProduto> estabelecimentosProdutos{ get; set; }
        
        public virtual IEnumerable<usuario> usuarios{ get; set; }
    }
}