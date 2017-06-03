using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootDex.Models
{
    public class Time
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [Required]
        [DisplayName("Técnico")]
        public int TecnicoID { get; set; }

        public virtual Tecnico Tecnico { get; set; }

        //public virtual ICollection<Jogador> Jogadors { get; set; }

        public double mediaATQ() { return 1; }
        public double mediaMEI() { return 1; }
        public double mediaDEF() { return 1; }
    }
}