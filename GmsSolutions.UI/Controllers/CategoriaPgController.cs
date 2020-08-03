using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GmsSolutions.DBreposotorio.Context;
using GmsSolutions.Entities;

namespace GmsSolutions.UI.Controllers
{
    public class CategoriaPgController : Controller
    {
        private LojaContext db = new LojaContext();

        // GET: CategoriaPg
        public ActionResult Index()
        {
            return View(db.CategoriaPgs.ToList());
        }

        // GET: CategoriaPg/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaPg categoriaPg = db.CategoriaPgs.Find(id);
            if (categoriaPg == null)
            {
                return HttpNotFound();
            }
            return View(categoriaPg);
        }

        // GET: CategoriaPg/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaPg/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] CategoriaPg categoriaPg)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaPgs.Add(categoriaPg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaPg);
        }

        // GET: CategoriaPg/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaPg categoriaPg = db.CategoriaPgs.Find(id);
            if (categoriaPg == null)
            {
                return HttpNotFound();
            }
            return View(categoriaPg);
        }

        // POST: CategoriaPg/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] CategoriaPg categoriaPg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaPg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaPg);
        }

        // GET: CategoriaPg/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaPg categoriaPg = db.CategoriaPgs.Find(id);
            if (categoriaPg == null)
            {
                return HttpNotFound();
            }
            return View(categoriaPg);
        }

        // POST: CategoriaPg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaPg categoriaPg = db.CategoriaPgs.Find(id);
            db.CategoriaPgs.Remove(categoriaPg);
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
