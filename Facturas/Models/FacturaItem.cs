using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturas.Models
{
    [Table("FacturasItems")]
   public class FacturaItem
    {
        [Key]
        [Column(Order = 0)]
        public int IdFactura { get; set; }
        [Key]
        [Column(Order = 1)]
        public int IdItem { get; set; }

        [ForeignKey("IdItem")]
        public Item item { get; set; }

    }
}
