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
    public class ModelssController : Controller
    {
        private Car24DataEntities db = new Car24DataEntities();

        // GET: Cingo/Modelss
        public ActionResult Index()
        {
            var model = db.model.Include(m => m.cat).Include(m => m.marka);
            return View(model.ToList());
        }

        // GET: Cingo/Modelss/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model model = db.model.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Cingo/Modelss/Create
        public ActionResult Create()
        {
            ViewBag.cat_id = new SelectList(db.cat, "id", "name");
            ViewBag.marka_id = new SelectList(db.marka, "id", "name");
            return View();
        }

        // POST: Cingo/Modelss/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cat_id,marka_id,name,model_id")] model model)
        {
            if (ModelState.IsValid)
            {
                db.model.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cat_id = new SelectList(db.cat, "id", "name", model.cat_id);
            ViewBag.marka_id = new SelectList(db.marka, "id", "name", model.marka_id);
            return View(model);
        }

        // GET: Cingo/Modelss/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model model = db.model.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.cat_id = new SelectList(db.cat, "id", "name", model.cat_id);
            ViewBag.marka_id = new SelectList(db.marka, "id", "name", model.marka_id);
            return View(model);
        }

        // POST: Cingo/Modelss/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cat_id,marka_id,name,model_id")] model model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cat_id = new SelectList(db.cat, "id", "name", model.cat_id);
            ViewBag.marka_id = new SelectList(db.marka, "id", "name", model.marka_id);
            return View(model);
        }

        // GET: Cingo/Modelss/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            model model = db.model.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Cingo/Modelss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            model model = db.model.Find(id);
            db.model.Remove(model);
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
