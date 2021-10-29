using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturas.Models
{
    [Table("Facturas")]
    public class Factura
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        [Column(TypeName = "char")] 
        [MaxLength(1)]
        public string Tipo { get; set; }

        public List<FacturaItem> FacturasItems { get; set; }
        public int Id_DocumentoComercial { get; set; }

        [ForeignKey("Id_DocumentoComercial")] 
        public DocumentoComercial DocumentoComercial { get; set; }
    }
}
