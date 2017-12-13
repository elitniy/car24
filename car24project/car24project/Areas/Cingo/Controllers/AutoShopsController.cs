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
    public class AutoShopsController : Controller
    {
        private Car24DataEntities db = new Car24DataEntities();

        // GET: Cingo/AutoShops
        public ActionResult Index()
        {
            return View(db.autoShops.ToList());
        }

        // GET: Cingo/AutoShops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            autoShops autoShops = db.autoShops.Find(id);
            if (autoShops == null)
            {
                return HttpNotFound();
            }
            return View(autoShops);
        }

        // GET: Cingo/AutoShops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cingo/AutoShops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,photos,txet,address")] autoShops autoShops)
        {
            if (ModelState.IsValid)
            {
                db.autoShops.Add(autoShops);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autoShops);
        }

        // GET: Cingo/AutoShops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            autoShops autoShops = db.autoShops.Find(id);
            if (autoShops == null)
            {
                return HttpNotFound();
            }
            return View(autoShops);
        }

        // POST: Cingo/AutoShops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,photos,txet,address")] autoShops autoShops)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoShops).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autoShops);
        }

        // GET: Cingo/AutoShops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            autoShops autoShops = db.autoShops.Find(id);
            if (autoShops == null)
            {
                return HttpNotFound();
            }
            return View(autoShops);
        }

        // POST: Cingo/AutoShops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            autoShops autoShops = db.autoShops.Find(id);
            db.autoShops.Remove(autoShops);
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
