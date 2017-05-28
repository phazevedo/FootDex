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
    public class PosicaosController : Controller
    {
        private ContextoBanco db = new ContextoBanco();

        // GET: Posicaos
        public ActionResult Index()
        {
            var posicao = db.Posicao.Include(p => p.Setor);
            return View(posicao.ToList());
        }

        // GET: Posicaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posicao posicao = db.Posicao.Find(id);
            if (posicao == null)
            {
                return HttpNotFound();
            }
            return View(posicao);
        }

        // GET: Posicaos/Create
        public ActionResult Create()
        {
            ViewBag.SetorId = new SelectList(db.Setor, "SetorId", "descricao");
            return View();
        }

        // POST: Posicaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PosicaoId,descricao,SetorId")] Posicao posicao)
        {
            if (ModelState.IsValid)
            {
                db.Posicao.Add(posicao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SetorId = new SelectList(db.Setor, "SetorId", "descricao", posicao.SetorId);
            return View(posicao);
        }

        // GET: Posicaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posicao posicao = db.Posicao.Find(id);
            if (posicao == null)
            {
                return HttpNotFound();
            }
            ViewBag.SetorId = new SelectList(db.Setor, "SetorId", "descricao", posicao.SetorId);
            return View(posicao);
        }

        // POST: Posicaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PosicaoId,descricao,SetorId")] Posicao posicao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posicao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SetorId = new SelectList(db.Setor, "SetorId", "descricao", posicao.SetorId);
            return View(posicao);
        }

        // GET: Posicaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posicao posicao = db.Posicao.Find(id);
            if (posicao == null)
            {
                return HttpNotFound();
            }
            return View(posicao);
        }

        // POST: Posicaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Posicao posicao = db.Posicao.Find(id);
            db.Posicao.Remove(posicao);
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
