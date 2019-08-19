using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models.Log;

namespace web.Models.Utils.Modulo
{
    [Table("modulo")]
    public class modulo
    {
        [Key]
        public int moduloID { get; set; }

        public string descricao { get; set; }

        public virtual IEnumerable<log> logs { get; set; }
    }
}