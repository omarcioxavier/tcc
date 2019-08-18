using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web.Models.Endereco
{
    [Table("endereco")]
    public class endereco
    {
        [Key]
        public int enderecoID { get; set; }

        public string  logradouro { get; set; }

        public string numero { get; set; }

        public string complemento { get; set; }

        public string bairro { get; set; }

        public string cep { get; set; }

        public int cidadeID { get; set; }
        
        public int estadoID { get; set; }

        public virtual cidade cidade { get; set; }
        
        public virtual estado estado { get; set; }
    }
}