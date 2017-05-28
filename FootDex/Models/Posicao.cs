using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootDex.Models
{
    public class Posicao
    {
        public int PosicaoId { get; set; }
        public string descricao { get; set; }
        public int SetorId { get; set; }

        public virtual Setor Setor { get; set; }
    }
}