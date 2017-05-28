namespace FootDex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atributoes",
                c => new
                    {
                        AtributoId = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                        SetorId = c.Int(nullable: false),
                        Jogador_JogadorId = c.Int(),
                    })
                .PrimaryKey(t => t.AtributoId)
                .ForeignKey("dbo.Setors", t => t.SetorId, cascadeDelete: true)
                .ForeignKey("dbo.Jogadors", t => t.Jogador_JogadorId)
                .Index(t => t.SetorId)
                .Index(t => t.Jogador_JogadorId);
            
            CreateTable(
                "dbo.Setors",
                c => new
                    {
                        SetorId = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                        peso_ataque = c.Decimal(nullable: false, precision: 18, scale: 2),
                        peso_meio_campo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        peso_defesa = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SetorId);
            
            CreateTable(
                "dbo.Posicaos",
                c => new
                    {
                        PosicaoId = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                        SetorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PosicaoId)
                .ForeignKey("dbo.Setors", t => t.SetorId, cascadeDelete: true)
                .Index(t => t.SetorId);
            
            CreateTable(
                "dbo.Jogadors",
                c => new
                    {
                        JogadorId = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        data_nascimento = c.DateTime(nullable: false),
                        PosicaoId = c.Int(nullable: false),
                        TimeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JogadorId)
                .ForeignKey("dbo.Posicaos", t => t.PosicaoId, cascadeDelete: true)
                .ForeignKey("dbo.Times", t => t.TimeId, cascadeDelete: true)
                .Index(t => t.PosicaoId)
                .Index(t => t.TimeId);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        TimeId = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        TecnicoID = c.Int(nullable: false),
                        LigaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TimeId)
                .ForeignKey("dbo.Ligas", t => t.LigaID, cascadeDelete: true)
                .ForeignKey("dbo.Tecnicoes", t => t.TecnicoID, cascadeDelete: true)
                .Index(t => t.TecnicoID)
                .Index(t => t.LigaID);
            
            CreateTable(
                "dbo.Ligas",
                c => new
                    {
                        LigaId = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                        pais = c.String(),
                    })
                .PrimaryKey(t => t.LigaId);
            
            CreateTable(
                "dbo.Tecnicoes",
                c => new
                    {
                        TecnicoId = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        data_nascimento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TecnicoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Times", "TecnicoID", "dbo.Tecnicoes");
            DropForeignKey("dbo.Times", "LigaID", "dbo.Ligas");
            DropForeignKey("dbo.Jogadors", "TimeId", "dbo.Times");
            DropForeignKey("dbo.Jogadors", "PosicaoId", "dbo.Posicaos");
            DropForeignKey("dbo.Atributoes", "Jogador_JogadorId", "dbo.Jogadors");
            DropForeignKey("dbo.Posicaos", "SetorId", "dbo.Setors");
            DropForeignKey("dbo.Atributoes", "SetorId", "dbo.Setors");
            DropIndex("dbo.Times", new[] { "LigaID" });
            DropIndex("dbo.Times", new[] { "TecnicoID" });
            DropIndex("dbo.Jogadors", new[] { "TimeId" });
            DropIndex("dbo.Jogadors", new[] { "PosicaoId" });
            DropIndex("dbo.Posicaos", new[] { "SetorId" });
            DropIndex("dbo.Atributoes", new[] { "Jogador_JogadorId" });
            DropIndex("dbo.Atributoes", new[] { "SetorId" });
            DropTable("dbo.Tecnicoes");
            DropTable("dbo.Ligas");
            DropTable("dbo.Times");
            DropTable("dbo.Jogadors");
            DropTable("dbo.Posicaos");
            DropTable("dbo.Setors");
            DropTable("dbo.Atributoes");
        }
    }
}
