using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models.Utils.Modulo;

namespace web.Models.Log
{
    [Table("log")]
    public class log
    {
        [Key]
        public int logID { get; set; }

        public string descricao { get; set; }

        public DateTime dataLog { get; set; }

        public int moduloID { get; set; }

        [ForeignKey("moduloID")]
        public virtual modulo modulo { get; set; }
    }
}