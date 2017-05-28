using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FootDex.Models
{
    public class ContextoBanco : DbContext
    {
        public ContextoBanco() : base("name=ConexaoDesenvolvimento") { }

        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Atributo> Atributo { get; set; }
        public DbSet<JogadorAtributo> JogadorAtributo { get; set; }
        public DbSet<Liga> Liga { get; set; }
        public DbSet<Posicao> Posicao { get; set; }
        public DbSet<Setor> Setor { get; set; }
        public DbSet<Tecnico> Tecnico { get; set; }
        public DbSet<Time> Time { get; set; }

    }
}