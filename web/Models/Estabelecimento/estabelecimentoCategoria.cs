using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models.Categoria;

namespace web.Models.Estabelecimento
{
    [Table("estabelecimentoCategoria")]
    public class estabelecimentoCategoria
    {
        [Key]
        public int estabelecimentoCategoriaID { get; set; }

        public int estabelecimentoID { get; set; }

        public int categoriaID { get; set; }

        public virtual estabelecimento estabelecimento{ get; set; }

        public virtual categoria categoria{ get; set; }
    }
}