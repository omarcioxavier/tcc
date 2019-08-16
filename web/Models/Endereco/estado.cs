using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models.Endereco
{
    [Table("estado")]
    public class estado
    {
        [Key]
        public int estadoID { get; set; }

        public string nome { get; set; }

        public string uf { get; set; }

        public virtual IEnumerable<cidade> cidades { get; set; }
    }
}