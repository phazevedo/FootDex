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
            ViewBag.PosicaoId = new SelectList(db.Posicao, "PosicaoId", "descricao");
            ViewBag.TimeId = new SelectList(db.Time, "TimeId", "nome");
            return View();
        }

        // POST: Jogadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JogadorId,nome,data_nascimento,PosicaoId,TimeId")] Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                db.Jogador.Add(jogador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PosicaoId = new SelectList(db.Posicao, "PosicaoId", "descricao", jogador.PosicaoId);
            ViewBag.TimeId = new SelectList(db.Time, "TimeId", "nome", jogador.TimeId);
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
            ViewBag.PosicaoId = new SelectList(db.Posicao, "PosicaoId", "descricao", jogador.PosicaoId);
            ViewBag.TimeId = new SelectList(db.Time, "TimeId", "nome", jogador.TimeId);
            return View(jogador);
        }

        // POST: Jogadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JogadorId,nome,data_nascimento,PosicaoId,TimeId")] Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jogador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PosicaoId = new SelectList(db.Posicao, "PosicaoId", "descricao", jogador.PosicaoId);
            ViewBag.TimeId = new SelectList(db.Time, "TimeId", "nome", jogador.TimeId);
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
