using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models.Estabelecimento
{
    [Table("estabelecimento")]
    public class estabelecimento
    {
        [Key]
        public int estabelecimentoID { get; set; }

        public string razaoSocial { get; set; }

        public string cnpj { get; set; }

        public string inscricaoEstadual { get; set; }

        public bool ativo { get; set; }
    }
}