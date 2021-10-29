namespace Facturas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambios1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FacturasItems", "IdFactura", "dbo.Facturas");
            DropForeignKey("dbo.RemitosItems", "Id_Item", "dbo.Items");
            DropPrimaryKey("dbo.FacturasItems");
            DropPrimaryKey("dbo.RemitosItems");
            AddPrimaryKey("dbo.FacturasItems", new[] { "IdFactura", "IdItem" });
            AddPrimaryKey("dbo.RemitosItems", new[] { "Id_Remito", "Id_Item" });
            AddForeignKey("dbo.FacturasItems", "IdFactura", "dbo.Facturas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RemitosItems", "Id_Item", "dbo.Items", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RemitosItems", "Id_Item", "dbo.Items");
            DropForeignKey("dbo.FacturasItems", "IdFactura", "dbo.Facturas");
            DropPrimaryKey("dbo.RemitosItems");
            DropPrimaryKey("dbo.FacturasItems");
            AddPrimaryKey("dbo.RemitosItems", "Id_Item");
            AddPrimaryKey("dbo.FacturasItems", "IdFactura");
            AddForeignKey("dbo.RemitosItems", "Id_Item", "dbo.Items", "Id");
            AddForeignKey("dbo.FacturasItems", "IdFactura", "dbo.Facturas", "Id");
        }
    }
}
