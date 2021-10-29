using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEF.Models
{
    [Table("Paciente")]
    public class Paciente
    {

        public int Id { get; set; }

        [Required] // not null
        [Column(TypeName = "varchar")] // tipo de dato sql server
        [MaxLength(50)] // hasta 50
        public string Nombre { get; set; }

        [Required] // not null
        [Column(TypeName = "varchar")] // tipo de dato sql server
        [MaxLength(50)] // hasta 50
        public string Apellido { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
        public int NroHistoriaClinica { get; set; }

        public int MedicoId { get; set; } //FK

        //propiedad de navegacion
        [ForeignKey("MedicoId")]
        public Medico medico { get; set; }
    }
}
