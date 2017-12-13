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
    public class ClubssController : Controller
    {
        private Car24DataEntities db = new Car24DataEntities();

        // GET: Cingo/Clubss
        public ActionResult Index()
        {
            return View(db.clubs.ToList());
        }

        // GET: Cingo/Clubss/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clubs clubs = db.clubs.Find(id);
            if (clubs == null)
            {
                return HttpNotFound();
            }
            return View(clubs);
        }

        // GET: Cingo/Clubss/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cingo/Clubss/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] clubs clubs)
        {
            if (ModelState.IsValid)
            {
                db.clubs.Add(clubs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clubs);
        }

        // GET: Cingo/Clubss/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clubs clubs = db.clubs.Find(id);
            if (clubs == null)
            {
                return HttpNotFound();
            }
            return View(clubs);
        }

        // POST: Cingo/Clubss/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] clubs clubs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clubs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clubs);
        }

        // GET: Cingo/Clubss/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clubs clubs = db.clubs.Find(id);
            if (clubs == null)
            {
                return HttpNotFound();
            }
            return View(clubs);
        }

        // POST: Cingo/Clubss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clubs clubs = db.clubs.Find(id);
            db.clubs.Remove(clubs);
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
