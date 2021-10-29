namespace WindowsEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregarentidades : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Especialidad",
                c => new
                    {
                        EspecialidadId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.EspecialidadId);
            
            CreateTable(
                "dbo.Habitacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Estado = c.String(nullable: false, maxLength: 12, unicode: false),
                        ClinicaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinica", t => t.ClinicaId, cascadeDelete: true)
                .Index(t => t.ClinicaId);
            
            CreateTable(
                "dbo.Clinica",
                c => new
                    {
                        ClinicaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        FechaInicioActividades = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.ClinicaId);
            
            AddColumn("dbo.Medicos", "EspecialidadId", c => c.Int(nullable: false));
            CreateIndex("dbo.Medicos", "EspecialidadId");
            AddForeignKey("dbo.Medicos", "EspecialidadId", "dbo.Especialidad", "EspecialidadId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicos", "EspecialidadId", "dbo.Especialidad");
            DropForeignKey("dbo.Habitacion", "ClinicaId", "dbo.Clinica");
            DropIndex("dbo.Medicos", new[] { "EspecialidadId" });
            DropIndex("dbo.Habitacion", new[] { "ClinicaId" });
            DropColumn("dbo.Medicos", "EspecialidadId");
            DropTable("dbo.Clinica");
            DropTable("dbo.Habitacion");
            DropTable("dbo.Especialidad");
        }
    }
}
