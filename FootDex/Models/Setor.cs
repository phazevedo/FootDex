using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootDex.Models
{
    public class Setor
    {
        public int SetorId { get; set; }
        public string descricao { get; set; }
        public decimal peso_ataque { get; set; }
        public decimal peso_meio_campo { get; set; }
        public decimal peso_defesa { get; set; }

        public virtual ICollection<Atributo> Atributos { get; set; }
        public virtual ICollection<Posicao> Posicaos { get; set; }
    }
}