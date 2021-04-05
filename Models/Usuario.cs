using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Back_end.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Apellido { get; set; }
        [Required]
        public int IdTipoIdentificacion { get; set; }
        [Required]
        public int NumeroIdentificacion { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Contraseña { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Correo { get; set; }

        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
    }
}
