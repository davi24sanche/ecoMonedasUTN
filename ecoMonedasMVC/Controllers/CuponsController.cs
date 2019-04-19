using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ecoMonedasMVC.Models;

namespace ecoMonedasMVC.Controllers
{
    public class CuponsController : Controller
    {
        private EcoContext db = new EcoContext();

        // GET: Cupons
        public ActionResult Index()
        {
            return View(db.Cupon.ToList());
        }

        // GET: Cupons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cupon cupon = db.Cupon.Find(id);
            if (cupon == null)
            {
                return HttpNotFound();
            }
            return View(cupon);
        }

        // GET: Cupons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cupons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Cantidad,CantidadEcoMonedas,FechaInicio,FechaFin,ProductoId")] Cupon cupon)
        {
            if (ModelState.IsValid)
            {
                db.Cupon.Add(cupon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cupon);
        }

        // GET: Cupons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cupon cupon = db.Cupon.Find(id);
            if (cupon == null)
            {
                return HttpNotFound();
            }
            return View(cupon);
        }

        // POST: Cupons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Cantidad,CantidadEcoMonedas,FechaInicio,FechaFin,ProductoId")] Cupon cupon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cupon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cupon);
        }

        // GET: Cupons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cupon cupon = db.Cupon.Find(id);
            if (cupon == null)
            {
                return HttpNotFound();
            }
            return View(cupon);
        }

        // POST: Cupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cupon cupon = db.Cupon.Find(id);
            db.Cupon.Remove(cupon);
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
