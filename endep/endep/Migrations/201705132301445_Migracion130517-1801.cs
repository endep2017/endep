namespace endep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion1305171801 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Equipoes", "UsuarioCrea", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Equipoes", "UsuarioCrea", c => c.String(nullable: false));
        }
    }
}
