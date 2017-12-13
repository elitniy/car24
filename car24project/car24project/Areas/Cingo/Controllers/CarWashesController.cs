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
    public class CarWashesController : Controller
    {
        private Car24DataEntities db = new Car24DataEntities();

        // GET: Cingo/CarWashes
        public ActionResult Index()
        {
            return View(db.carWash.ToList());
        }

        // GET: Cingo/CarWashes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carWash carWash = db.carWash.Find(id);
            if (carWash == null)
            {
                return HttpNotFound();
            }
            return View(carWash);
        }

        // GET: Cingo/CarWashes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cingo/CarWashes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] carWash carWash)
        {
            if (ModelState.IsValid)
            {
                db.carWash.Add(carWash);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carWash);
        }

        // GET: Cingo/CarWashes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carWash carWash = db.carWash.Find(id);
            if (carWash == null)
            {
                return HttpNotFound();
            }
            return View(carWash);
        }

        // POST: Cingo/CarWashes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] carWash carWash)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carWash).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carWash);
        }

        // GET: Cingo/CarWashes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carWash carWash = db.carWash.Find(id);
            if (carWash == null)
            {
                return HttpNotFound();
            }
            return View(carWash);
        }

        // POST: Cingo/CarWashes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            carWash carWash = db.carWash.Find(id);
            db.carWash.Remove(carWash);
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
