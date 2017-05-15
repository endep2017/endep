namespace endep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion1205171939 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipoes", "UsuarioCrea", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Equipoes", "UsuarioCrea");
        }
    }
}
