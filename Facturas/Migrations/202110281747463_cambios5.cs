namespace Facturas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambios5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RemitosItems", "Remito_Id", c => c.Int());
            CreateIndex("dbo.RemitosItems", "Remito_Id");
            AddForeignKey("dbo.RemitosItems", "Remito_Id", "dbo.Remitos", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RemitosItems", "Remito_Id", "dbo.Remitos");
            DropIndex("dbo.RemitosItems", new[] { "Remito_Id" });
            DropColumn("dbo.RemitosItems", "Remito_Id");
        }
    }
}
