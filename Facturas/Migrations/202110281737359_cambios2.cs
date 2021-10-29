namespace Facturas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambios2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RemitosItems", "Id_Remito", "dbo.Remitos");
            DropForeignKey("dbo.FacturasItems", "IdFactura", "dbo.Facturas");
            DropIndex("dbo.FacturasItems", new[] { "IdFactura" });
            DropIndex("dbo.RemitosItems", new[] { "Id_Remito" });
            AddColumn("dbo.FacturasItems", "Factura_Id", c => c.Int());
            CreateIndex("dbo.FacturasItems", "Factura_Id");
            AddForeignKey("dbo.FacturasItems", "Factura_Id", "dbo.Facturas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacturasItems", "Factura_Id", "dbo.Facturas");
            DropIndex("dbo.FacturasItems", new[] { "Factura_Id" });
            DropColumn("dbo.FacturasItems", "Factura_Id");
            CreateIndex("dbo.RemitosItems", "Id_Remito");
            CreateIndex("dbo.FacturasItems", "IdFactura");
            AddForeignKey("dbo.FacturasItems", "IdFactura", "dbo.Facturas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RemitosItems", "Id_Remito", "dbo.Remitos", "Id", cascadeDelete: true);
        }
    }
}
