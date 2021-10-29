using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturas.Models
{
    [Table("DocumentosComerciales")]
    public class DocumentoComercial
    {
        public int Id { get; set; }
        public int Numero { get; set; }

        [Required]

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Cliente { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string Direccion { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string CondicionIva { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string CondicionVenta { get; set; }
          // aca habia una factura singulas con la fk
        public List<Factura> Facturas { get; set; }
        public List<Remito> Remitos { get; set; }



    }
    }
