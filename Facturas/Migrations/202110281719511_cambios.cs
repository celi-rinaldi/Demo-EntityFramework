namespace Facturas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocumentosComerciales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false, storeType: "date"),
                        Cliente = c.String(maxLength: 50, unicode: false),
                        Direccion = c.String(maxLength: 100, unicode: false),
                        CondicionIva = c.String(maxLength: 50, unicode: false),
                        CondicionVenta = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false),
                        Id_DocumentoComercial = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentosComerciales", t => t.Id_DocumentoComercial, cascadeDelete: true)
                .Index(t => t.Id_DocumentoComercial);
            
            CreateTable(
                "dbo.FacturasItems",
                c => new
                    {
                        IdFactura = c.Int(nullable: false),
                        IdItem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFactura)
                .ForeignKey("dbo.Facturas", t => t.IdFactura)
                .ForeignKey("dbo.Items", t => t.IdItem, cascadeDelete: true)
                .Index(t => t.IdFactura)
                .Index(t => t.IdItem);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        Descripcion = c.String(),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Remitos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaEntrega = c.DateTime(nullable: false),
                        Id_DocumentoComercial = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentosComerciales", t => t.Id_DocumentoComercial, cascadeDelete: true)
                .Index(t => t.Id_DocumentoComercial);
            
            CreateTable(
                "dbo.RemitosItems",
                c => new
                    {
                        Id_Item = c.Int(nullable: false),
                        Id_Remito = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Item)
                .ForeignKey("dbo.Items", t => t.Id_Item)
                .ForeignKey("dbo.Remitos", t => t.Id_Remito, cascadeDelete: true)
                .Index(t => t.Id_Item)
                .Index(t => t.Id_Remito);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RemitosItems", "Id_Remito", "dbo.Remitos");
            DropForeignKey("dbo.RemitosItems", "Id_Item", "dbo.Items");
            DropForeignKey("dbo.Remitos", "Id_DocumentoComercial", "dbo.DocumentosComerciales");
            DropForeignKey("dbo.FacturasItems", "IdItem", "dbo.Items");
            DropForeignKey("dbo.FacturasItems", "IdFactura", "dbo.Facturas");
            DropForeignKey("dbo.Facturas", "Id_DocumentoComercial", "dbo.DocumentosComerciales");
            DropIndex("dbo.RemitosItems", new[] { "Id_Remito" });
            DropIndex("dbo.RemitosItems", new[] { "Id_Item" });
            DropIndex("dbo.Remitos", new[] { "Id_DocumentoComercial" });
            DropIndex("dbo.FacturasItems", new[] { "IdItem" });
            DropIndex("dbo.FacturasItems", new[] { "IdFactura" });
            DropIndex("dbo.Facturas", new[] { "Id_DocumentoComercial" });
            DropTable("dbo.RemitosItems");
            DropTable("dbo.Remitos");
            DropTable("dbo.Items");
            DropTable("dbo.FacturasItems");
            DropTable("dbo.Facturas");
            DropTable("dbo.DocumentosComerciales");
        }
    }
}
