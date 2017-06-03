namespace FootDex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePesosSetor : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Setors", "PesoATK");
            DropColumn("dbo.Setors", "PesoML");
            DropColumn("dbo.Setors", "PesoDEF");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Setors", "PesoDEF", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Setors", "PesoML", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Setors", "PesoATK", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
