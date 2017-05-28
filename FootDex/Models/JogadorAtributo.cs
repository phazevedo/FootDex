using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FootDex.Models
{
    public class JogadorAtributo
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Atributo")]
        public int AtributoID { get; set; }
        public virtual Atributo Atributo { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Jogador")]
        public int JogadorID { get; set; }
        public virtual Jogador Jogador { get; set; }

        [Range(1, 99,ErrorMessage = "O valor do atributo deve estar entre 1 e 99")]
        public int Valor { get; set; }

    }
}