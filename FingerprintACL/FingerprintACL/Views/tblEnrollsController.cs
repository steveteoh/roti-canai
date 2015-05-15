using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FingerprintACL.Models;

namespace FingerprintACL.Views
{
    public class tblEnrollsController : Controller
    {
        private DEMOEntities db = new DEMOEntities();

        // GET: tblEnrolls
        public ActionResult Index()
        {
            return View(db.tblEnrolls.ToList());
        }

        // GET: tblEnrolls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEnroll tblEnroll = db.tblEnrolls.Find(id);
            if (tblEnroll == null)
            {
                return HttpNotFound();
            }
            return View(tblEnroll);
        }

        // GET: tblEnrolls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblEnrolls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StaffID,Finger,Template,quality")] tblEnroll tblEnroll)
        {
            if (ModelState.IsValid)
            {
                db.tblEnrolls.Add(tblEnroll);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEnroll);
        }

        // GET: tblEnrolls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEnroll tblEnroll = db.tblEnrolls.Find(id);
            if (tblEnroll == null)
            {
                return HttpNotFound();
            }
            return View(tblEnroll);
        }

        // POST: tblEnrolls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StaffID,Finger,Template,quality")] tblEnroll tblEnroll)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEnroll).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEnroll);
        }

        // GET: tblEnrolls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEnroll tblEnroll = db.tblEnrolls.Find(id);
            if (tblEnroll == null)
            {
                return HttpNotFound();
            }
            return View(tblEnroll);
        }

        // POST: tblEnrolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEnroll tblEnroll = db.tblEnrolls.Find(id);
            db.tblEnrolls.Remove(tblEnroll);
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
