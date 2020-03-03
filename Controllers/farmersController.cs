using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gurleen200356784.Models;

namespace Gurleen200356784.Controllers
{
    public class farmersController : Controller
    {
        private DataModel db = new DataModel();

        // GET: farmers
        public ActionResult Index()
        {
            var farmers = db.farmers.Include(f => f.crop);
            return View(farmers.ToList());
        }

        // GET: farmers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            farmer farmer = db.farmers.Find(id);
            if (farmer == null)
            {
                return HttpNotFound();
            }
            return View(farmer);
        }

        // GET: farmers/Create
        public ActionResult Create()
        {
            ViewBag.cropid = new SelectList(db.crops, "cropid", "cropname");
            return View();
        }

        // POST: farmers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "farmerid,farmername,cropid")] farmer farmer)
        {
            if (ModelState.IsValid)
            {
                db.farmers.Add(farmer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cropid = new SelectList(db.crops, "cropid", "cropname", farmer.cropid);
            return View(farmer);
        }

        // GET: farmers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            farmer farmer = db.farmers.Find(id);
            if (farmer == null)
            {
                return HttpNotFound();
            }
            ViewBag.cropid = new SelectList(db.crops, "cropid", "cropname", farmer.cropid);
            return View(farmer);
        }

        // POST: farmers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "farmerid,farmername,cropid")] farmer farmer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farmer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cropid = new SelectList(db.crops, "cropid", "cropname", farmer.cropid);
            return View(farmer);
        }

        // GET: farmers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            farmer farmer = db.farmers.Find(id);
            if (farmer == null)
            {
                return HttpNotFound();
            }
            return View(farmer);
        }

        // POST: farmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            farmer farmer = db.farmers.Find(id);
            db.farmers.Remove(farmer);
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
