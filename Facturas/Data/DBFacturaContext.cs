using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facturas.Models; 

namespace Facturas.Context
{
    class DBFacturaContext:DbContext
    {
        public DBFacturaContext():base("KeyDBFactura") { }

        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Remito> Remitos { get; set; }
        public DbSet<DocumentoComercial> DocumentosComerciales { get; set; }
        public DbSet<FacturaItem> FacturasItems { get; set; }
        public DbSet<RemitoItem> RemitosItems { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
