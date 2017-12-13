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
    public class UsersTypesController : Controller
    {
        private Car24DataEntities db = new Car24DataEntities();

        // GET: Cingo/UsersTypes
        public ActionResult Index()
        {
            return View(db.usersType.ToList());
        }

        // GET: Cingo/UsersTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usersType usersType = db.usersType.Find(id);
            if (usersType == null)
            {
                return HttpNotFound();
            }
            return View(usersType);
        }

        // GET: Cingo/UsersTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cingo/UsersTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] usersType usersType)
        {
            if (ModelState.IsValid)
            {
                db.usersType.Add(usersType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usersType);
        }

        // GET: Cingo/UsersTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usersType usersType = db.usersType.Find(id);
            if (usersType == null)
            {
                return HttpNotFound();
            }
            return View(usersType);
        }

        // POST: Cingo/UsersTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] usersType usersType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usersType);
        }

        // GET: Cingo/UsersTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usersType usersType = db.usersType.Find(id);
            if (usersType == null)
            {
                return HttpNotFound();
            }
            return View(usersType);
        }

        // POST: Cingo/UsersTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usersType usersType = db.usersType.Find(id);
            db.usersType.Remove(usersType);
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
