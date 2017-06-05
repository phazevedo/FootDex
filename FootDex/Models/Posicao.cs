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
        public enum Setor { ATQ = 1, MEI, DEF }
        public int ID { get; set; }
        [Required]
        [DisplayName("Posição")]
        public string Descricao { get; set; }
        [Required]
        [DisplayName("Setor")]
        public int SetorID { get; set; }


        public Posicao(string descricao, int setor)
        {
            Descricao = descricao;
            SetorID = setor;
        }

        public Posicao() { }

    }

}