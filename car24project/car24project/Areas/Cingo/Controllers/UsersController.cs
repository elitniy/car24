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
    public class UsersController : Controller
    {
        private Car24DataEntities db = new Car24DataEntities();

        // GET: Cingo/Users
        public ActionResult Index()
        {
            var users = db.users.Include(u => u.countries).Include(u => u.gender).Include(u => u.sities).Include(u => u.usersType);
            return View(users.ToList());
        }

        // GET: Cingo/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Cingo/Users/Create
        public ActionResult Create()
        {
            ViewBag.countryID = new SelectList(db.countries, "id", "name");
            ViewBag.genderID = new SelectList(db.gender, "id", "name");
            ViewBag.sityID = new SelectList(db.sities, "id", "name");
            ViewBag.usersTypeID = new SelectList(db.usersType, "id", "id");
            return View();
        }

        // POST: Cingo/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,surname,login,email,password,countryID,sityID,genderID,photo,usersTypeID")] users users)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.countryID = new SelectList(db.countries, "id", "name", users.countryID);
            ViewBag.genderID = new SelectList(db.gender, "id", "name", users.genderID);
            ViewBag.sityID = new SelectList(db.sities, "id", "name", users.sityID);
            ViewBag.usersTypeID = new SelectList(db.usersType, "id", "id", users.usersTypeID);
            return View(users);
        }

        // GET: Cingo/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            ViewBag.countryID = new SelectList(db.countries, "id", "name", users.countryID);
            ViewBag.genderID = new SelectList(db.gender, "id", "name", users.genderID);
            ViewBag.sityID = new SelectList(db.sities, "id", "name", users.sityID);
            ViewBag.usersTypeID = new SelectList(db.usersType, "id", "id", users.usersTypeID);
            return View(users);
        }

        // POST: Cingo/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,surname,login,email,password,countryID,sityID,genderID,photo,usersTypeID")] users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.countryID = new SelectList(db.countries, "id", "name", users.countryID);
            ViewBag.genderID = new SelectList(db.gender, "id", "name", users.genderID);
            ViewBag.sityID = new SelectList(db.sities, "id", "name", users.sityID);
            ViewBag.usersTypeID = new SelectList(db.usersType, "id", "id", users.usersTypeID);
            return View(users);
        }

        // GET: Cingo/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Cingo/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            users users = db.users.Find(id);
            db.users.Remove(users);
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
