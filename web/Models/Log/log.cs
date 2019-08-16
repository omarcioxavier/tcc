using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models.Log
{
    [Table("log")]
    public class log
    {
        [Key]
        public int logID { get; set; }

        public string descricao { get; set; }

        public DateTime dataHora { get; set; }

        public int usuarioID { get; set; }
    }
}