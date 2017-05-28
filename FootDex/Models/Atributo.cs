using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootDex.Models
{
    public class Atributo
    {
        public int AtributoId { get; set; }
        public string descricao { get; set; }
        public int SetorId { get; set; }

        public virtual Setor Setor { get; set; }
        public virtual JogadorAtributo JogadorAtributoes { get; set; }


    }
}