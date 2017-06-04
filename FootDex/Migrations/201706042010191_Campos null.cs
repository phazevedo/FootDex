namespace FootDex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Camposnull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jogadors", "TimeID", "dbo.Times");
            DropIndex("dbo.Jogadors", new[] { "TimeID" });
            AlterColumn("dbo.Jogadors", "TimeID", c => c.Int());
            CreateIndex("dbo.Jogadors", "TimeID");
            AddForeignKey("dbo.Jogadors", "TimeID", "dbo.Times", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jogadors", "TimeID", "dbo.Times");
            DropIndex("dbo.Jogadors", new[] { "TimeID" });
            AlterColumn("dbo.Jogadors", "TimeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Jogadors", "TimeID");
            AddForeignKey("dbo.Jogadors", "TimeID", "dbo.Times", "ID", cascadeDelete: true);
        }
    }
}
