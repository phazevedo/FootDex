using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootDex.Models
{
    public class Setor
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}