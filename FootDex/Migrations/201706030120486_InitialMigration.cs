namespace FootDex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jogadors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        PosicaoID = c.Int(nullable: false),
                        Media = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TimeID = c.Int(nullable: false),
                        HabilidadeGoleiro = c.Int(nullable: false),
                        Forca = c.Int(nullable: false),
                        Marcacao = c.Int(nullable: false),
                        Carrinho = c.Int(nullable: false),
                        PasseCurto = c.Int(nullable: false),
                        PasseLongo = c.Int(nullable: false),
                        Cruzamento = c.Int(nullable: false),
                        VisaoDeJogo = c.Int(nullable: false),
                        Finalizacao = c.Int(nullable: false),
                        Cabeceio = c.Int(nullable: false),
                        Dibre = c.Int(nullable: false),
                        Velocidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posicaos", t => t.PosicaoID, cascadeDelete: true)
                .ForeignKey("dbo.Times", t => t.TimeID, cascadeDelete: true)
                .Index(t => t.PosicaoID)
                .Index(t => t.TimeID);
            
            CreateTable(
                "dbo.Posicaos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        SetorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Setors", t => t.SetorID, cascadeDelete: true)
                .Index(t => t.SetorID);
            
            CreateTable(
                "dbo.Setors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        PesoATK = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PesoML = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PesoDEF = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        TecnicoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tecnicoes", t => t.TecnicoID, cascadeDelete: true)
                .Index(t => t.TecnicoID);
            
            CreateTable(
                "dbo.Tecnicoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jogadors", "TimeID", "dbo.Times");
            DropForeignKey("dbo.Times", "TecnicoID", "dbo.Tecnicoes");
            DropForeignKey("dbo.Jogadors", "PosicaoID", "dbo.Posicaos");
            DropForeignKey("dbo.Posicaos", "SetorID", "dbo.Setors");
            DropIndex("dbo.Times", new[] { "TecnicoID" });
            DropIndex("dbo.Posicaos", new[] { "SetorID" });
            DropIndex("dbo.Jogadors", new[] { "TimeID" });
            DropIndex("dbo.Jogadors", new[] { "PosicaoID" });
            DropTable("dbo.Tecnicoes");
            DropTable("dbo.Times");
            DropTable("dbo.Setors");
            DropTable("dbo.Posicaos");
            DropTable("dbo.Jogadors");
        }
    }
}
