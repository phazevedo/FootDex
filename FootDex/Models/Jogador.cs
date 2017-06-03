using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootDex.Models
{
    public class Jogador
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [DisplayName("Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
        [Required]
        [DisplayName("Posição")]
        public int PosicaoID { get; set; }
        [DisplayName("Média")]
        public decimal Media { get; set; }
        [DisplayName("Time")]
        public int TimeID { get; set; }

        public virtual Posicao Posicao { get; set; }   
        public virtual Time Time { get; set; }

        //ATRIBUTOS DEFESA
        [Required]
        [DisplayName("Habilidade Goleiro")]
        public int HabilidadeGoleiro { get; set; }
        [Required]
        [DisplayName("Força")]
        public int Forca { get; set; }
        [Required]
        [DisplayName("Marcação")]
        public int Marcacao { get; set; }
        [Required]
        [DisplayName("Carrinho")]
        public int Carrinho { get; set; }

        //ATRIBUTOS MEIO-CAMPO
        [Required]
        [DisplayName("Passe Curto")]
        public int PasseCurto { get; set; }
        [Required]
        [DisplayName("Passe Longo")]
        public int PasseLongo { get; set; }
        [Required]
        [DisplayName("Cruzamento")]
        public int Cruzamento { get; set; }
        [Required]
        [DisplayName("Visão de Jogo")]
        public int VisaoDeJogo { get; set; }

        //ATRIBUTOS ATAQUE
        [Required]
        [DisplayName("Finalização")]
        public int Finalizacao { get; set; }
        [Required]
        [DisplayName("Cabeceio")]
        public int Cabeceio { get; set; }
        [Required]
        [DisplayName("Dibre")]
        public int Dibre { get; set; }
        [Required]
        [DisplayName("Velocidade")]
        public int Velocidade { get; set; }

        public double mediaATQ() 
        {
            return (Finalizacao + Cabeceio + Dibre + Velocidade)/4;
        }

        public double mediaMEI()
        {
            return (VisaoDeJogo + PasseLongo + PasseLongo + Cruzamento)/4;
        }

        public double mediaDEF()
        {
            return (Forca + HabilidadeGoleiro + Marcacao + Carrinho)/4;
        }
    }
}