namespace FootDex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RetirarRequiredTecnicos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Times", "TecnicoID", "dbo.Tecnicoes");
            DropIndex("dbo.Times", new[] { "TecnicoID" });
            AlterColumn("dbo.Times", "TecnicoID", c => c.Int());
            CreateIndex("dbo.Times", "TecnicoID");
            AddForeignKey("dbo.Times", "TecnicoID", "dbo.Tecnicoes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Times", "TecnicoID", "dbo.Tecnicoes");
            DropIndex("dbo.Times", new[] { "TecnicoID" });
            AlterColumn("dbo.Times", "TecnicoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Times", "TecnicoID");
            AddForeignKey("dbo.Times", "TecnicoID", "dbo.Tecnicoes", "ID", cascadeDelete: true);
        }
    }
}
