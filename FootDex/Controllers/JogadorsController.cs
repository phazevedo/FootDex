using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootDex.Models;

namespace FootDex.Controllers
{
    public class JogadorsController : Controller
    {
        private ContextoBanco db = new ContextoBanco();

        // GET: Jogadors
        public ActionResult Index()
        {
            var jogador = db.Jogador.Include(j => j.Posicao).Include(j => j.Time);
            return View(jogador.ToList());
        }

        // GET: Jogadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogador jogador = db.Jogador.Find(id);
            if (jogador == null)
            {
                return HttpNotFound();
            }
            return View(jogador);
        }

        // GET: Jogadors/Create
        public ActionResult Create()
        {
            ViewBag.PosicaoID = new SelectList(db.Posicao, "ID", "Descricao");
            ViewBag.TimeID = new SelectList(db.Time, "ID", "Nome");
            return View();
        }

        // POST: Jogadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,DataNascimento,PosicaoID,Media,TimeID,HabilidadeGoleiro,Forca,Marcacao,Carrinho,PasseCurto,PasseLongo,Cruzamento,VisaoDeJogo,Finalizacao,Cabeceio,Dibre,Velocidade")] Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                jogador.Media = CalculaMedia(jogador);
                db.Jogador.Add(jogador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PosicaoID = new SelectList(db.Posicao, "ID", "Descricao", jogador.PosicaoID);
            ViewBag.TimeID = new SelectList(db.Time, "ID", "Nome", jogador.TimeID);
            return View(jogador);
        }

        // GET: Jogadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogador jogador = db.Jogador.Find(id);
            if (jogador == null)
            {
                return HttpNotFound();
            }
            ViewBag.PosicaoID = new SelectList(db.Posicao, "ID", "Descricao", jogador.PosicaoID);
            ViewBag.TimeID = new SelectList(db.Time, "ID", "Nome", jogador.TimeID);
            return View(jogador);
        }

        // POST: Jogadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,DataNascimento,PosicaoID,Media,TimeID,HabilidadeGoleiro,Forca,Marcacao,Carrinho,PasseCurto,PasseLongo,Cruzamento,VisaoDeJogo,Finalizacao,Cabeceio,Dibre,Velocidade")] Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                jogador.Media = CalculaMedia(jogador);
                db.Entry(jogador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PosicaoID = new SelectList(db.Posicao, "ID", "Descricao", jogador.PosicaoID);
            ViewBag.TimeID = new SelectList(db.Time, "ID", "Nome", jogador.TimeID);
            return View(jogador);
        }

        // GET: Jogadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogador jogador = db.Jogador.Find(id);
            if (jogador == null)
            {
                return HttpNotFound();
            }
            return View(jogador);
        }

        // POST: Jogadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogador jogador = db.Jogador.Find(id);
            db.Jogador.Remove(jogador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public decimal CalculaMedia(Jogador jogador)
        {
            decimal Media = 0;
            Media = (jogador.Cabeceio + jogador.Carrinho + jogador.Cruzamento + jogador.Dibre + jogador.Finalizacao + jogador.Forca + jogador.HabilidadeGoleiro +
                jogador.Marcacao + jogador.PasseCurto + jogador.PasseLongo + jogador.Velocidade + jogador.VisaoDeJogo);
            Media = Media / 12;
            return Math.Round(Media);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
