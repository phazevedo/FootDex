using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootDex.Models
{
    public class Tecnico
    {
        public int TecnicoId { get; set; }
        public string nome { get; set; }
        public DateTime data_nascimento { get; set; }
    }
}