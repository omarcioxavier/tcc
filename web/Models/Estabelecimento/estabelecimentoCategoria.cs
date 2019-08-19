using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models.Estabelecimento
{
    [Table("estabelecimentoCategoria")]
    public class estabelecimentoCategoria
    {
        [Key]
        public int estabelecimentoCategoriaID { get; set; }

        public string descricao { get; set; }

        public virtual IEnumerable<estabelecimento> estabelecimentos{ get; set; }
    }
}