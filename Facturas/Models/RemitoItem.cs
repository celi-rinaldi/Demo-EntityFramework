﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturas.Models
{
    [Table("RemitosItems")]
    public class RemitoItem
    {
        [Key]
        [Column(Order = 0)]
        public int Id_Remito { get; set; }
        [Key]
        [Column(Order = 1)]
        public int Id_Item { get; set; }

        [ForeignKey("Id_Item")]
        public Item Item { get; set; }
       // [ForeignKey("Id_Remito")]
       // public Remito Remito { get; set; }
    }
}
