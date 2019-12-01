using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models.Pedido
{
    [Table("pagamento")]
    public class pagamento
    {
        [Key]
        public int pagamentoID { get; set; }

        public string descricao { get; set; }

        public virtual IEnumerable<pedido> pedidos { get; set; }
    }
}