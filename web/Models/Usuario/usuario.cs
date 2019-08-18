using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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