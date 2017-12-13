using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using car24project.Models;

namespace car24project.Areas.Cingo.Controllers
{
    public class MarkasController : Controller
    {
        private Car24DataEntities db = new Car24DataEntities();

        // GET: Cingo/Markas
        public ActionResult Index()
        {
            var marka = db.marka.Include(m => m.cat).Include(m => m.marka_norm);
            return View(marka.ToList());
        }

        // GET: Cingo/Markas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            marka marka = db.marka.Find(id);
            if (marka == null)
            {
                return HttpNotFound();
            }
            return View(marka);
        }

        // GET: Cingo/Markas/Create
        public ActionResult Create()
        {
            ViewBag.cat_id = new SelectList(db.cat, "id", "name");
            ViewBag.marka_id = new SelectList(db.marka_norm, "id", "name");
            return View();
        }

        // POST: Cingo/Markas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cat_id,name,marka_id")] marka marka)
        {
            if (ModelState.IsValid)
            {
                db.marka.Add(marka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cat_id = new SelectList(db.cat, "id", "name", marka.cat_id);
            ViewBag.marka_id = new SelectList(db.marka_norm, "id", "name", marka.marka_id);
            return View(marka);
        }

        // GET: Cingo/Markas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            marka marka = db.marka.Find(id);
            if (marka == null)
            {
                return HttpNotFound();
            }
            ViewBag.cat_id = new SelectList(db.cat, "id", "name", marka.cat_id);
            ViewBag.marka_id = new SelectList(db.marka_norm, "id", "name", marka.marka_id);
            return View(marka);
        }

        // POST: Cingo/Markas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cat_id,name,marka_id")] marka marka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cat_id = new SelectList(db.cat, "id", "name", marka.cat_id);
            ViewBag.marka_id = new SelectList(db.marka_norm, "id", "name", marka.marka_id);
            return View(marka);
        }

        // GET: Cingo/Markas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            marka marka = db.marka.Find(id);
            if (marka == null)
            {
                return HttpNotFound();
            }
            return View(marka);
        }

        // POST: Cingo/Markas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            marka marka = db.marka.Find(id);
            db.marka.Remove(marka);
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
