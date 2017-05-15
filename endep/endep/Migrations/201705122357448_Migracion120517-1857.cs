namespace endep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion1205171857 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Equipoes", "Nombre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Equipoes", "Nombre", c => c.String());
        }
    }
}
