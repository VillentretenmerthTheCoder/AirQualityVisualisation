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
    public class Final_ViewController : Controller
    {
        private AirData_F2019Entities3 db = new AirData_F2019Entities3();

        // GET: Final_View
        public ActionResult Index()
        {
            return View(db.Final_View.ToList().Take(50));
        }

        // GET: Final_View/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Final_View final_View = db.Final_View.Find(id);
            if (final_View == null)
            {
                return HttpNotFound();
            }
            return View(final_View);
        }

        // GET: Final_View/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Final_View/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DatoMaerke,Navn,ProduktId,RaaResultat,Kode,StofNavn,Expr1")] Final_View final_View)
        {
            if (ModelState.IsValid)
            {
                db.Final_View.Add(final_View);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(final_View);
        }

        // GET: Final_View/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Final_View final_View = db.Final_View.Find(id);
            if (final_View == null)
            {
                return HttpNotFound();
            }
            return View(final_View);
        }

        // POST: Final_View/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DatoMaerke,Navn,ProduktId,RaaResultat,Kode,StofNavn,Expr1")] Final_View final_View)
        {
            if (ModelState.IsValid)
            {
                db.Entry(final_View).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(final_View);
        }

        // GET: Final_View/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Final_View final_View = db.Final_View.Find(id);
            if (final_View == null)
            {
                return HttpNotFound();
            }
            return View(final_View);
        }

        // POST: Final_View/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Final_View final_View = db.Final_View.Find(id);
            db.Final_View.Remove(final_View);
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
