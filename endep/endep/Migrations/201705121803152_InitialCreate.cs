namespace endep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ControlDominios",
                c => new
                    {
                        DominioId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        PadreId = c.String(),
                        vigente = c.String(),
                        Abreviatura = c.String(),
                        Observacion = c.String(),
                    })
                .PrimaryKey(t => t.DominioId);
            
            CreateTable(
                "dbo.Equipoes",
                c => new
                    {
                        EquipoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.EquipoId)
                .Index(t => t.EquipoId, unique: true, name: "Equipo_Index");
            
            CreateTable(
                "dbo.IntegranteEquipoes",
                c => new
                    {
                        IntegranteEquipoId = c.Int(nullable: false, identity: true),
                        id = c.String(),
                        PosicionId = c.Int(nullable: false),
                        EquipoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IntegranteEquipoId)
                .ForeignKey("dbo.Equipoes", t => t.EquipoId, cascadeDelete: true)
                .ForeignKey("dbo.Posicions", t => t.PosicionId, cascadeDelete: true)
                .Index(t => t.PosicionId)
                .Index(t => t.EquipoId);
            
            CreateTable(
                "dbo.Posicions",
                c => new
                    {
                        PosicionId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.PosicionId);
            
            CreateTable(
                "dbo.LugarGeograficoes",
                c => new
                    {
                        LugarId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        PadreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LugarId);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Email = c.String(),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        Identificacion = c.String(),
                        Sexo = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        PaisResidencia = c.String(),
                        DtoResidencia = c.String(),
                        CiudadResidencia = c.String(),
                        Imagen = c.String(),
                        DocumentoId = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Rol_RolId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Rols", t => t.Rol_RolId)
                .Index(t => t.Rol_RolId);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        RolId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Persona_UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RolId)
                .ForeignKey("dbo.Personas", t => t.Persona_UserId)
                .Index(t => t.Persona_UserId);
            
            CreateTable(
                "dbo.PruebaPersonas",
                c => new
                    {
                        PesonaId = c.String(nullable: false, maxLength: 128),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        Identificacion = c.String(),
                        DocumentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PesonaId)
                .ForeignKey("dbo.TipoDocumentoes", t => t.DocumentoId, cascadeDelete: true)
                .Index(t => t.DocumentoId);
            
            CreateTable(
                "dbo.TipoDocumentoes",
                c => new
                    {
                        DocumentoId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.DocumentoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PruebaPersonas", "DocumentoId", "dbo.TipoDocumentoes");
            DropForeignKey("dbo.Rols", "Persona_UserId", "dbo.Personas");
            DropForeignKey("dbo.Personas", "Rol_RolId", "dbo.Rols");
            DropForeignKey("dbo.IntegranteEquipoes", "PosicionId", "dbo.Posicions");
            DropForeignKey("dbo.IntegranteEquipoes", "EquipoId", "dbo.Equipoes");
            DropIndex("dbo.PruebaPersonas", new[] { "DocumentoId" });
            DropIndex("dbo.Rols", new[] { "Persona_UserId" });
            DropIndex("dbo.Personas", new[] { "Rol_RolId" });
            DropIndex("dbo.IntegranteEquipoes", new[] { "EquipoId" });
            DropIndex("dbo.IntegranteEquipoes", new[] { "PosicionId" });
            DropIndex("dbo.Equipoes", "Equipo_Index");
            DropTable("dbo.TipoDocumentoes");
            DropTable("dbo.PruebaPersonas");
            DropTable("dbo.Rols");
            DropTable("dbo.Personas");
            DropTable("dbo.LugarGeograficoes");
            DropTable("dbo.Posicions");
            DropTable("dbo.IntegranteEquipoes");
            DropTable("dbo.Equipoes");
            DropTable("dbo.ControlDominios");
        }
    }
}
