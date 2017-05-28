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
    public class TimesController : Controller
    {
        private ContextoBanco db = new ContextoBanco();

        // GET: Times
        public ActionResult Index()
        {
            var time = db.Time.Include(t => t.Liga).Include(t => t.Tecnico);
            return View(time.ToList());
        }

        // GET: Times/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Time.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            return View(time);
        }

        // GET: Times/Create
        public ActionResult Create()
        {
            ViewBag.LigaID = new SelectList(db.Liga, "LigaId", "descricao");
            ViewBag.TecnicoID = new SelectList(db.Tecnico, "TecnicoId", "nome");
            return View();
        }

        // POST: Times/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TimeId,nome,TecnicoID,LigaID")] Time time)
        {
            if (ModelState.IsValid)
            {
                db.Time.Add(time);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LigaID = new SelectList(db.Liga, "LigaId", "descricao", time.LigaID);
            ViewBag.TecnicoID = new SelectList(db.Tecnico, "TecnicoId", "nome", time.TecnicoID);
            return View(time);
        }

        // GET: Times/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Time.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            ViewBag.LigaID = new SelectList(db.Liga, "LigaId", "descricao", time.LigaID);
            ViewBag.TecnicoID = new SelectList(db.Tecnico, "TecnicoId", "nome", time.TecnicoID);
            return View(time);
        }

        // POST: Times/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TimeId,nome,TecnicoID,LigaID")] Time time)
        {
            if (ModelState.IsValid)
            {
                db.Entry(time).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LigaID = new SelectList(db.Liga, "LigaId", "descricao", time.LigaID);
            ViewBag.TecnicoID = new SelectList(db.Tecnico, "TecnicoId", "nome", time.TecnicoID);
            return View(time);
        }

        // GET: Times/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Time.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            return View(time);
        }

        // POST: Times/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Time time = db.Time.Find(id);
            db.Time.Remove(time);
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
