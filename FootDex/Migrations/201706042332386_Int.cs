namespace FootDex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Int : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jogadors", "Media", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jogadors", "Media", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
