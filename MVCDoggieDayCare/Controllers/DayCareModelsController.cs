using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDoggieDayCare.Models;

namespace MVCDoggieDayCare.Controllers
{
    public class DayCareModelsController : Controller
    {
        private MVCDoggieDayCareContext db = new MVCDoggieDayCareContext();

        // GET: DayCareModels
        public ActionResult Index()
        {
            return View(db.DayCareModels.ToList());
        }

        // GET: DayCareModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayCareModel dayCareModel = db.DayCareModels.Find(id);
            if (dayCareModel == null)
            {
                return HttpNotFound();
            }
            return View(dayCareModel);
        }

        // GET: DayCareModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DayCareModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PetID,PetName,Male,Weight")] DayCareModel dayCareModel)
        {
            if (ModelState.IsValid)
            {
                db.DayCareModels.Add(dayCareModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dayCareModel);
        }

        // GET: DayCareModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayCareModel dayCareModel = db.DayCareModels.Find(id);
            if (dayCareModel == null)
            {
                return HttpNotFound();
            }
            return View(dayCareModel);
        }

        // POST: DayCareModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PetID,PetName,Male,Weight")] DayCareModel dayCareModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dayCareModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dayCareModel);
        }

        // GET: DayCareModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayCareModel dayCareModel = db.DayCareModels.Find(id);
            if (dayCareModel == null)
            {
                return HttpNotFound();
            }
            return View(dayCareModel);
        }

        // POST: DayCareModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DayCareModel dayCareModel = db.DayCareModels.Find(id);
            db.DayCareModels.Remove(dayCareModel);
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
