using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models.Estabelecimento;
using web.Models.Produto;

namespace web.Models.Cliente
{
    [Table("clienteVenda")]
    public class clienteVenda
    {
        [Key]
        public int clienteVendaID { get; set; }

        public DateTime dataVenda { get; set; }

        public int clienteID { get; set; }

        public int estabelecimentoID { get; set; }

        public int produtoVendaID { get; set; }

        public virtual cliente cliente { get; set; }

        public virtual estabelecimento estabelecimento { get; set; }

        public virtual produtoVenda produtoVenda { get; set; }
    }
}