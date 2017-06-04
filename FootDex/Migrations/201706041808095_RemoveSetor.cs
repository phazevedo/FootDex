namespace FootDex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSetor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posicaos", "SetorID", "dbo.Setors");
            DropIndex("dbo.Posicaos", new[] { "SetorID" });
            DropTable("dbo.Setors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Setors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Posicaos", "SetorID");
            AddForeignKey("dbo.Posicaos", "SetorID", "dbo.Setors", "ID", cascadeDelete: true);
        }
    }
}
