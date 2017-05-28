using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootDex.Models
{
    public class Jogador
    {
        public int JogadorId { get; set; }
        public string nome { get; set; }
        public DateTime data_nascimento { get; set; }
        public int PosicaoId { get; set; }
        public int TimeId { get; set; }

        public virtual Posicao Posicao { get; set; }   
        public virtual Time Time { get; set; }

        public virtual ICollection<JogadorAtributo> JogadorAtributoes { get; set; }
    }
}