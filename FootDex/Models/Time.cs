using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootDex.Models
{
    public class Time
    {
        public int TimeId { get; set; }
        public string nome { get; set; }
        public int TecnicoID { get; set; }
        public int LigaID { get; set; }

        public virtual Tecnico Tecnico { get; set; }
        public virtual Liga Liga { get; set; }

        public virtual ICollection<Jogador> Jogadors { get; set; }
    }
}