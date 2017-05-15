namespace endep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion1405171306 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IntegranteEquipoes", "Estado", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.IntegranteEquipoes", "Estado");
        }
    }
}
