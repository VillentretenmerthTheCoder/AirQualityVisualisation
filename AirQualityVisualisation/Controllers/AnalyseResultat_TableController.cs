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
    public class AnalyseResultat_TableController : Controller
    {
        private AirData_F2019Entities3 db = new AirData_F2019Entities3();

        // GET: AnalyseResultat_Table
        public ActionResult Index()
        {
            var analyseResultat_Table = db.AnalyseResultat_Table.Include(a => a.Stof_Table).Include(a => a.Unit_Table).Take(50);
            return View(analyseResultat_Table.ToList());
        }

        // GET: AnalyseResultat_Table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnalyseResultat_Table analyseResultat_Table = db.AnalyseResultat_Table.Find(id);
            if (analyseResultat_Table == null)
            {
                return HttpNotFound();
            }
            return View(analyseResultat_Table);
        }

        // GET: AnalyseResultat_Table/Create
        public ActionResult Create()
        {
            ViewBag.StofId = new SelectList(db.Stof_Table, "StofId", "StofNavn");
            ViewBag.RaaEnhedId = new SelectList(db.Unit_Table, "EnhedId", "Navn");
            return View();
        }

        // POST: AnalyseResultat_Table/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnalyseResultatId,StofId,AnalyseInstruksId,DataTypeId,RaaResultat,RaaEnhedId,ProjektResultat,ProjektEnhedId,AnalyseDato,ProduktId")] AnalyseResultat_Table analyseResultat_Table)
        {
            if (ModelState.IsValid)
            {
                db.AnalyseResultat_Table.Add(analyseResultat_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StofId = new SelectList(db.Stof_Table, "StofId", "StofNavn", analyseResultat_Table.StofId);
            ViewBag.RaaEnhedId = new SelectList(db.Unit_Table, "EnhedId", "Navn", analyseResultat_Table.RaaEnhedId);
            return View(analyseResultat_Table);
        }

        // GET: AnalyseResultat_Table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnalyseResultat_Table analyseResultat_Table = db.AnalyseResultat_Table.Find(id);
            if (analyseResultat_Table == null)
            {
                return HttpNotFound();
            }
            ViewBag.StofId = new SelectList(db.Stof_Table, "StofId", "StofNavn", analyseResultat_Table.StofId);
            ViewBag.RaaEnhedId = new SelectList(db.Unit_Table, "EnhedId", "Navn", analyseResultat_Table.RaaEnhedId);
            return View(analyseResultat_Table);
        }

        // POST: AnalyseResultat_Table/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnalyseResultatId,StofId,AnalyseInstruksId,DataTypeId,RaaResultat,RaaEnhedId,ProjektResultat,ProjektEnhedId,AnalyseDato,ProduktId")] AnalyseResultat_Table analyseResultat_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(analyseResultat_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StofId = new SelectList(db.Stof_Table, "StofId", "StofNavn", analyseResultat_Table.StofId);
            ViewBag.RaaEnhedId = new SelectList(db.Unit_Table, "EnhedId", "Navn", analyseResultat_Table.RaaEnhedId);
            return View(analyseResultat_Table);
        }

        // GET: AnalyseResultat_Table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnalyseResultat_Table analyseResultat_Table = db.AnalyseResultat_Table.Find(id);
            if (analyseResultat_Table == null)
            {
                return HttpNotFound();
            }
            return View(analyseResultat_Table);
        }

        // POST: AnalyseResultat_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnalyseResultat_Table analyseResultat_Table = db.AnalyseResultat_Table.Find(id);
            db.AnalyseResultat_Table.Remove(analyseResultat_Table);
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
