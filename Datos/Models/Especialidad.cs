using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    [Table("Especialidades")]
    public class Especialidad
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Nombre { get; set; }
    }
}
