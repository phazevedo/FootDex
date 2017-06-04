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

        public decimal mediaATQ() {
            List<Jogador> lstJogadores = getJogadores((int)Posicao.Setor_teste.ATQ);
            decimal media = 0;
            if (lstJogadores.Count < 1)
                return 0;
            foreach (Jogador jog in lstJogadores)
            {
                media += jog.mediaGeral();
            }
            return media / lstJogadores.Count;
        }
        public decimal mediaMEI() {
            List<Jogador> lstJogadores = getJogadores((int)Posicao.Setor_teste.MEI);
            decimal media = 0;
            if (lstJogadores.Count < 1)
                return 0;
            foreach (Jogador jog in lstJogadores)
            {
                media += jog.mediaGeral();
            }
            return media / lstJogadores.Count;
        }
        public decimal mediaDEF() {
            List<Jogador> lstJogadores = getJogadores((int)Posicao.Setor_teste.DEF);
            decimal media = 0;
            if (lstJogadores.Count < 1)
                return 0;
            foreach (Jogador jog in lstJogadores)
            {
                media += jog.mediaGeral();
            }
            return media / lstJogadores.Count;
        }

        public List<Jogador> getJogadores(int setor) {
            ContextoBanco db = new ContextoBanco();
            return db.Jogador.Where(j => j.TimeID == ID).Where(j => j.Posicao.SetorID == setor).ToList();
        }
    }
}