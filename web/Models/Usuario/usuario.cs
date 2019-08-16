using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace web.Models.Usuario
{
    [Table("usuario")]
    public class usuario
    {
        [Key]
        public int usuarioID { get; set; }

        public string email { get; set; }

        public string password { get; set; }
        
        public DateTime dataCadastro { get; set; }
    }
}