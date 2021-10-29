using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturas.Models
{
    [Table("Remitos")]
    public class Remito
    {
        public int Id { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int Id_DocumentoComercial { get; set; }
        [ForeignKey("Id_DocumentoComercial")]
        public DocumentoComercial DocumentoComercial { get; set; }
        public List<RemitoItem> RemitosItems { get; set; }


    }
}
