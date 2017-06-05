using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootDex.Models
{
    public class Tecnico
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Técnico")]
        public string Nome { get; set; }
        [DisplayName("Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
    }
}