using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirQualityVisualisation.Models;

namespace AirQualityVisualisation.Controllers
{
    public class Aktivitet_TableController : Controller
    {
        private AirData_F2019Entities3 db = new AirData_F2019Entities3();

        // GET: Aktivitet_Table
        public ActionResult Index()
        {
            var aktivitet_Table = db.Aktivitet_Table.Include(a => a.Opstilling_Table).Take(50);
            return View(aktivitet_Table.ToList());
        }

        // GET: Aktivitet_Table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aktivitet_Table aktivitet_Table = db.Aktivitet_Table.Find(id);
            if (aktivitet_Table == null)
            {
                return HttpNotFound();
            }
            return View(aktivitet_Table);
        }

        // GET: Aktivitet_Table/Create
        public ActionResult Create()
        {
            ViewBag.OpstillingId = new SelectList(db.Opstilling_Table, "OpstillingId", "Kode");
            return View();
        }

        // POST: Aktivitet_Table/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AktivitetId,AktivitetTypeId,OpstillingId,DatoMaerke,ExpPeriodeTypeId")] Aktivitet_Table aktivitet_Table)
        {
            if (ModelState.IsValid)
            {
                db.Aktivitet_Table.Add(aktivitet_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OpstillingId = new SelectList(db.Opstilling_Table, "OpstillingId", "Kode", aktivitet_Table.OpstillingId);
            return View(aktivitet_Table);
        }

        // GET: Aktivitet_Table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aktivitet_Table aktivitet_Table = db.Aktivitet_Table.Find(id);
            if (aktivitet_Table == null)
            {
                return HttpNotFound();
            }
            ViewBag.OpstillingId = new SelectList(db.Opstilling_Table, "OpstillingId", "Kode", aktivitet_Table.OpstillingId);
            return View(aktivitet_Table);
        }

        // POST: Aktivitet_Table/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AktivitetId,AktivitetTypeId,OpstillingId,DatoMaerke,ExpPeriodeTypeId")] Aktivitet_Table aktivitet_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aktivitet_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OpstillingId = new SelectList(db.Opstilling_Table, "OpstillingId", "Kode", aktivitet_Table.OpstillingId);
            return View(aktivitet_Table);
        }

        // GET: Aktivitet_Table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aktivitet_Table aktivitet_Table = db.Aktivitet_Table.Find(id);
            if (aktivitet_Table == null)
            {
                return HttpNotFound();
            }
            return View(aktivitet_Table);
        }

        // POST: Aktivitet_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aktivitet_Table aktivitet_Table = db.Aktivitet_Table.Find(id);
            db.Aktivitet_Table.Remove(aktivitet_Table);
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
