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
    public class Product_TableController : Controller
    {
        private AirData_F2019Entities3 db = new AirData_F2019Entities3();

        // GET: Product_Table
        public ActionResult Index()
        {
            var product_Table = db.Product_Table.Include(p => p.Aktivitet_Table).Include(p => p.Measurement_Table).Include(p => p.ProductType_Table).Include(p => p.Proeve_Table).Take(50);
            return View(product_Table.ToList());
        }

        // GET: Product_Table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Table product_Table = db.Product_Table.Find(id);
            if (product_Table == null)
            {
                return HttpNotFound();
            }
            return View(product_Table);
        }

        // GET: Product_Table/Create
        public ActionResult Create()
        {
            ViewBag.AktivitetId = new SelectList(db.Aktivitet_Table, "AktivitetId", "AktivitetId");
            ViewBag.ProduktId = new SelectList(db.Measurement_Table, "ProduktId", "ProduktId");
            ViewBag.ProduktTypeId = new SelectList(db.ProductType_Table, "ProduktTypeId", "Navn");
            ViewBag.ProduktId = new SelectList(db.Proeve_Table, "ProduktId", "ProduktId");
            return View();
        }

        // POST: Product_Table/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProduktId,AktivitetId,ProduktTypeId")] Product_Table product_Table)
        {
            if (ModelState.IsValid)
            {
                db.Product_Table.Add(product_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AktivitetId = new SelectList(db.Aktivitet_Table, "AktivitetId", "AktivitetId", product_Table.AktivitetId);
            ViewBag.ProduktId = new SelectList(db.Measurement_Table, "ProduktId", "ProduktId", product_Table.ProduktId);
            ViewBag.ProduktTypeId = new SelectList(db.ProductType_Table, "ProduktTypeId", "Navn", product_Table.ProduktTypeId);
            ViewBag.ProduktId = new SelectList(db.Proeve_Table, "ProduktId", "ProduktId", product_Table.ProduktId);
            return View(product_Table);
        }

        // GET: Product_Table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Table product_Table = db.Product_Table.Find(id);
            if (product_Table == null)
            {
                return HttpNotFound();
            }
            ViewBag.AktivitetId = new SelectList(db.Aktivitet_Table, "AktivitetId", "AktivitetId", product_Table.AktivitetId);
            ViewBag.ProduktId = new SelectList(db.Measurement_Table, "ProduktId", "ProduktId", product_Table.ProduktId);
            ViewBag.ProduktTypeId = new SelectList(db.ProductType_Table, "ProduktTypeId", "Navn", product_Table.ProduktTypeId);
            ViewBag.ProduktId = new SelectList(db.Proeve_Table, "ProduktId", "ProduktId", product_Table.ProduktId);
            return View(product_Table);
        }

        // POST: Product_Table/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProduktId,AktivitetId,ProduktTypeId")] Product_Table product_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AktivitetId = new SelectList(db.Aktivitet_Table, "AktivitetId", "AktivitetId", product_Table.AktivitetId);
            ViewBag.ProduktId = new SelectList(db.Measurement_Table, "ProduktId", "ProduktId", product_Table.ProduktId);
            ViewBag.ProduktTypeId = new SelectList(db.ProductType_Table, "ProduktTypeId", "Navn", product_Table.ProduktTypeId);
            ViewBag.ProduktId = new SelectList(db.Proeve_Table, "ProduktId", "ProduktId", product_Table.ProduktId);
            return View(product_Table);
        }

        // GET: Product_Table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Table product_Table = db.Product_Table.Find(id);
            if (product_Table == null)
            {
                return HttpNotFound();
            }
            return View(product_Table);
        }

        // POST: Product_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_Table product_Table = db.Product_Table.Find(id);
            db.Product_Table.Remove(product_Table);
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
