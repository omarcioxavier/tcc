using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models.Estabelecimento;

namespace web.Models.Usuario
{
    [Table("usuario")]
    public class usuario
    {
        [Key]
        public int usuarioID { get; set; }

        public string login { get; set; }

        public string senha { get; set; }

        public bool ativo { get; set; }

        public bool estadoSessao { get; set; }

        public int estabelecimentoID { get; set; }

        [ForeignKey("estabelecimentoID")]
        public virtual estabelecimento  estabelecimento { get; set; }
    }
}