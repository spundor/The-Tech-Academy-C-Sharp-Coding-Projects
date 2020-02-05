
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsuranceAppMVC.Models;

namespace CarInsuranceAppMVC.Controllers
{
    public class InsureeController : Controller
    {
        private CarInsuranceEntities db = new CarInsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAdresss,DateofBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insurees)
        {
            {
                insurees.Quote = 50.0m;

                for (int i = 0; i < insurees.SpeedingTickets; i++)
                {
                    insurees.Quote += 10;
                }

                if ((DateTime.Now.Year - insurees.DateofBirth.Year < 18))
                {
                    insurees.Quote += 100;
                }
                if ((DateTime.Now.Year - insurees.DateofBirth.Year > 18 && DateTime.Now.Year - insurees.DateofBirth.Year < 25))
                {
                    insurees.Quote += 25;
                }
                if ((DateTime.Now.Year - insurees.DateofBirth.Year > 100))
                {
                    insurees.Quote += 25;
                }
                if (Convert.ToInt32(insurees.CarYear) < 2000)
                {
                    insurees.Quote += 25;
                }
                if (Convert.ToInt32(insurees.CarYear) > 2015)
                {
                    insurees.Quote += 25;
                }
                if (insurees.CarMake == "Porsche")
                {
                    insurees.Quote += 25;
                }
                if (insurees.CarMake == "Porsche" && insurees.CarModel == "911 Carrera")
                {
                    insurees.Quote += 25;
                }
                if (insurees.DUI == true)
                {
                    insurees.Quote *= 1.25m;
                }
                if (insurees.CoverageType == true)
                {
                    insurees.Quote *= 1.50m;
                }
            }
            if (ModelState.IsValid)
            {
                db.Insurees.Add(insurees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insurees);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAdresss,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
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