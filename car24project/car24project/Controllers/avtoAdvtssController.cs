using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using car24project.Models;

namespace car24project.Controllers
{
    public class avtoAdvtssController : Controller
    {
        private Car24DataEntities db = new Car24DataEntities();

        // GET: avtoAdvtss
        public ActionResult Index()
        {
            var avtoAdvt = db.avtoAdvt.Include(a => a.bodyType1).Include(a => a.color).Include(a => a.driveUnit).Include(a => a.engineVolume).Include(a => a.fuelType).Include(a => a.graduationYear).Include(a => a.marka).Include(a => a.model).Include(a => a.motorPower).Include(a => a.transmission);
            return View(avtoAdvt.ToList());
        }

        // GET: avtoAdvtss/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            avtoAdvt avtoAdvt = db.avtoAdvt.Find(id);
            if (avtoAdvt == null)
            {
                return HttpNotFound();
            }
            return View(avtoAdvt);
        }

        // GET: avtoAdvtss/Create
        public ActionResult Create()
        {
            ViewBag.bodyType = new SelectList(db.bodyType, "id", "name");
            ViewBag.colorID = new SelectList(db.color, "id", "name");
            ViewBag.driveUintID = new SelectList(db.driveUnit, "id", "name");
            ViewBag.engineVolumeID = new SelectList(db.engineVolume, "id", "name");
            ViewBag.fuelTypeID = new SelectList(db.fuelType, "id", "name");
            ViewBag.graduationYearID = new SelectList(db.graduationYear, "id", "id");
            ViewBag.markaID = new SelectList(db.marka, "id", "name");
            ViewBag.modelID = new SelectList(db.model, "id", "name");
            ViewBag.motorPowerID = new SelectList(db.motorPower, "id", "name");
            ViewBag.transmissionID = new SelectList(db.transmission, "id", "name");
            return View();
        }

        // POST: avtoAdvtss/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,price,photo,markaID,modelID,bodyType,colorID,engineVolumeID,motorPowerID,fuelTypeID,graduationYearID,mileage,driveUintID,transmissionID,additionalInfo,phone,contactsName,publicDate,viewSize")] avtoAdvt avtoAdvt)
        {
            if (ModelState.IsValid)
            {
                db.avtoAdvt.Add(avtoAdvt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bodyType = new SelectList(db.bodyType, "id", "name", avtoAdvt.bodyType);
            ViewBag.colorID = new SelectList(db.color, "id", "name", avtoAdvt.colorID);
            ViewBag.driveUintID = new SelectList(db.driveUnit, "id", "name", avtoAdvt.driveUintID);
            ViewBag.engineVolumeID = new SelectList(db.engineVolume, "id", "name", avtoAdvt.engineVolumeID);
            ViewBag.fuelTypeID = new SelectList(db.fuelType, "id", "name", avtoAdvt.fuelTypeID);
            ViewBag.graduationYearID = new SelectList(db.graduationYear, "id", "id", avtoAdvt.graduationYearID);
            ViewBag.markaID = new SelectList(db.marka, "id", "name", avtoAdvt.markaID);
            ViewBag.modelID = new SelectList(db.model, "id", "name", avtoAdvt.modelID);
            ViewBag.motorPowerID = new SelectList(db.motorPower, "id", "name", avtoAdvt.motorPowerID);
            ViewBag.transmissionID = new SelectList(db.transmission, "id", "name", avtoAdvt.transmissionID);
            return View(avtoAdvt);
        }

        // GET: avtoAdvtss/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            avtoAdvt avtoAdvt = db.avtoAdvt.Find(id);
            if (avtoAdvt == null)
            {
                return HttpNotFound();
            }
            ViewBag.bodyType = new SelectList(db.bodyType, "id", "name", avtoAdvt.bodyType);
            ViewBag.colorID = new SelectList(db.color, "id", "name", avtoAdvt.colorID);
            ViewBag.driveUintID = new SelectList(db.driveUnit, "id", "name", avtoAdvt.driveUintID);
            ViewBag.engineVolumeID = new SelectList(db.engineVolume, "id", "name", avtoAdvt.engineVolumeID);
            ViewBag.fuelTypeID = new SelectList(db.fuelType, "id", "name", avtoAdvt.fuelTypeID);
            ViewBag.graduationYearID = new SelectList(db.graduationYear, "id", "id", avtoAdvt.graduationYearID);
            ViewBag.markaID = new SelectList(db.marka, "id", "name", avtoAdvt.markaID);
            ViewBag.modelID = new SelectList(db.model, "id", "name", avtoAdvt.modelID);
            ViewBag.motorPowerID = new SelectList(db.motorPower, "id", "name", avtoAdvt.motorPowerID);
            ViewBag.transmissionID = new SelectList(db.transmission, "id", "name", avtoAdvt.transmissionID);
            return View(avtoAdvt);
        }

        // POST: avtoAdvtss/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,price,photo,markaID,modelID,bodyType,colorID,engineVolumeID,motorPowerID,fuelTypeID,graduationYearID,mileage,driveUintID,transmissionID,additionalInfo,phone,contactsName,publicDate,viewSize")] avtoAdvt avtoAdvt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avtoAdvt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bodyType = new SelectList(db.bodyType, "id", "name", avtoAdvt.bodyType);
            ViewBag.colorID = new SelectList(db.color, "id", "name", avtoAdvt.colorID);
            ViewBag.driveUintID = new SelectList(db.driveUnit, "id", "name", avtoAdvt.driveUintID);
            ViewBag.engineVolumeID = new SelectList(db.engineVolume, "id", "name", avtoAdvt.engineVolumeID);
            ViewBag.fuelTypeID = new SelectList(db.fuelType, "id", "name", avtoAdvt.fuelTypeID);
            ViewBag.graduationYearID = new SelectList(db.graduationYear, "id", "id", avtoAdvt.graduationYearID);
            ViewBag.markaID = new SelectList(db.marka, "id", "name", avtoAdvt.markaID);
            ViewBag.modelID = new SelectList(db.model, "id", "name", avtoAdvt.modelID);
            ViewBag.motorPowerID = new SelectList(db.motorPower, "id", "name", avtoAdvt.motorPowerID);
            ViewBag.transmissionID = new SelectList(db.transmission, "id", "name", avtoAdvt.transmissionID);
            return View(avtoAdvt);
        }

        // GET: avtoAdvtss/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            avtoAdvt avtoAdvt = db.avtoAdvt.Find(id);
            if (avtoAdvt == null)
            {
                return HttpNotFound();
            }
            return View(avtoAdvt);
        }

        // POST: avtoAdvtss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            avtoAdvt avtoAdvt = db.avtoAdvt.Find(id);
            db.avtoAdvt.Remove(avtoAdvt);
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
