using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models.Endereco
{
    [Table("cidade")]
    public class cidade
    {
        [Key]
        public int cidadeID { get; set; }

        public string nome { get; set; }

        public int estadoID { get; set; }

        [ForeignKey("estadoID")]
        public virtual estado estado { get; set; }
    }
}