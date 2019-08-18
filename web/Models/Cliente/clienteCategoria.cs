using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models.Categoria;

namespace web.Models.Cliente
{
    [Table("clienteCategoria")]
    public class clienteCategoria
    {
        [Key]
        public int categoriaClienteID { get; set; }

        public int clienteID { get; set; }

        public int categoriaID { get; set; }

        [ForeignKey("clienteID")]
        public virtual cliente cliente { get; set; }

        [ForeignKey("categoriaID")]
        public virtual categoria categoria { get; set; }
    }
}