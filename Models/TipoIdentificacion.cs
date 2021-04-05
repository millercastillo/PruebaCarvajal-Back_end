using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Back_end.Models
{
    public class TipoIdentificacion
    {
        [Key]
        public int IdTipoIdentificacion { get; set; }
        [Required]

        [Column(TypeName = "varchar(10)")]
        public string Codigo { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Descripcion { get; set; }
    }
}
