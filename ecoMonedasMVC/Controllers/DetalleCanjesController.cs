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
    public class DetalleCanjesController : Controller
    {
        private EcoContext db = new EcoContext();

        // GET: DetalleCanjes
        public ActionResult Index()
        {
            var detalleCanjes = db.DetalleCanjes.Include(d => d.Canjes).Include(d => d.Material);
            return View(detalleCanjes.ToList());
        }

        // GET: DetalleCanjes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCanjes detalleCanjes = db.DetalleCanjes.Find(id);
            if (detalleCanjes == null)
            {
                return HttpNotFound();
            }
            return View(detalleCanjes);
        }

        // GET: DetalleCanjes/Create
        public ActionResult Create()
        {
            ViewBag.Canje_id = new SelectList(db.Canjes, "id", "UsuarioId");
            ViewBag.Material_id = new SelectList(db.Material, "id", "nombre");
            return View();
        }

        // POST: DetalleCanjes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cantidad,Monto,Canje_id,Material_id")] DetalleCanjes detalleCanjes)
        {
            if (ModelState.IsValid)
            {
                db.DetalleCanjes.Add(detalleCanjes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Canje_id = new SelectList(db.Canjes, "id", "UsuarioId", detalleCanjes.Canje_id);
            ViewBag.Material_id = new SelectList(db.Material, "id", "nombre", detalleCanjes.Material_id);
            return View(detalleCanjes);
        }

        // GET: DetalleCanjes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCanjes detalleCanjes = db.DetalleCanjes.Find(id);
            if (detalleCanjes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Canje_id = new SelectList(db.Canjes, "id", "UsuarioId", detalleCanjes.Canje_id);
            ViewBag.Material_id = new SelectList(db.Material, "id", "nombre", detalleCanjes.Material_id);
            return View(detalleCanjes);
        }

        // POST: DetalleCanjes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cantidad,Monto,Canje_id,Material_id")] DetalleCanjes detalleCanjes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleCanjes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Canje_id = new SelectList(db.Canjes, "id", "UsuarioId", detalleCanjes.Canje_id);
            ViewBag.Material_id = new SelectList(db.Material, "id", "nombre", detalleCanjes.Material_id);
            return View(detalleCanjes);
        }

        // GET: DetalleCanjes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCanjes detalleCanjes = db.DetalleCanjes.Find(id);
            if (detalleCanjes == null)
            {
                return HttpNotFound();
            }
            return View(detalleCanjes);
        }

        // POST: DetalleCanjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleCanjes detalleCanjes = db.DetalleCanjes.Find(id);
            db.DetalleCanjes.Remove(detalleCanjes);
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
