﻿using System;
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
        [DisplayName("Time")]
        public string Nome { get; set; }
        [DisplayName("Técnico")]
        public int? TecnicoID { get; set; }

        public virtual Tecnico Tecnico { get; set; }

        //public virtual ICollection<Jogador> Jogadors { get; set; }

        public decimal mediaATQ()
        {
            List<Jogador> lstJogadores = getJogadores((int)Posicao.Setor.ATQ);
            decimal media = 0;
            if (lstJogadores.Count < 1)
                return 0;
            foreach (Jogador jog in lstJogadores)
            {
                media += jog.mediaGeral();
            }
            return media / lstJogadores.Count;
        }
        public decimal mediaMEI()
        {
            List<Jogador> lstJogadores = getJogadores((int)Posicao.Setor.MEI);
            decimal media = 0;
            if (lstJogadores.Count < 1)
                return 0;
            foreach (Jogador jog in lstJogadores)
            {
                media += jog.mediaGeral();
            }
            return media / lstJogadores.Count;
        }
        public decimal mediaDEF()
        {
            List<Jogador> lstJogadores = getJogadores((int)Posicao.Setor.DEF);
            decimal media = 0;
            if (lstJogadores.Count < 1)
                return 0;
            foreach (Jogador jog in lstJogadores)
            {
                media += jog.mediaGeral();
            }
            return media / lstJogadores.Count;
        }

        public List<Jogador> getJogadores(int? setor = null)
        {
            ContextoBanco db = new ContextoBanco();
            if (setor == null)
                return db.Jogador.Where(j => j.TimeID == ID).ToList();
            return db.Jogador.Where(j => j.TimeID == ID).Where(j => j.Posicao.SetorID == setor).ToList();
        }
    }
}