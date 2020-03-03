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
    public class cropsController : Controller
    {
        private DataModel db = new DataModel();

        // GET: crops
        public ActionResult Index()
        {
            return View(db.crops.ToList());
        }

        // GET: crops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            crop crop = db.crops.Find(id);
            if (crop == null)
            {
                return HttpNotFound();
            }
            return View(crop);
        }

        // GET: crops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: crops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cropid,cropname,seasonal")] crop crop)
        {
            if (ModelState.IsValid)
            {
                db.crops.Add(crop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crop);
        }

        // GET: crops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            crop crop = db.crops.Find(id);
            if (crop == null)
            {
                return HttpNotFound();
            }
            return View(crop);
        }

        // POST: crops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cropid,cropname,seasonal")] crop crop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crop);
        }

        // GET: crops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            crop crop = db.crops.Find(id);
            if (crop == null)
            {
                return HttpNotFound();
            }
            return View(crop);
        }

        // POST: crops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            crop crop = db.crops.Find(id);
            db.crops.Remove(crop);
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
