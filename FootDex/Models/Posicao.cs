using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootDex.Models
{
    public class Posicao
    {
        public enum Setor_teste { ATQ = 1, MEI, DEF}
        public int ID { get; set; }
        [Required]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        [Required]
        [DisplayName("Setor")]
        public int SetorID { get; set; }

        public virtual Setor Setor { get; set; }
    }
}