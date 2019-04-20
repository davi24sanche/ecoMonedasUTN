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
    public class CanjesController : Controller
    {
        private EcoContext db = new EcoContext();

        // GET: Canjes
        public ActionResult Index()
        {
            var canjes = db.Canjes.Include(c => c.CentroAcopio).Include(c => c.Material).Include(c => c.Usuario);
            return View(canjes.ToList());
        }

        // GET: Canjes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canjes canjes = db.Canjes.Find(id);
            if (canjes == null)
            {
                return HttpNotFound();
            }
            return View(canjes);
        }

        // GET: Canjes/Create
        public ActionResult Create()
        {
            ViewBag.CentroAcopioId = new SelectList(db.CentroAcopio, "Id", "Nombre");
            ViewBag.MaterialId = new SelectList(db.Material, "id", "nombre");
            ViewBag.ClienteId = new SelectList(db.Usuario, "Email", "Nombre");
            return View();
        }

        // POST: Canjes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UsuarioId,CentroAcopioId,Cantidad,MaterialId,ClienteId,Fecha")] Canjes canjes)
        {
            if (ModelState.IsValid)
            {
                db.Canjes.Add(canjes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CentroAcopioId = new SelectList(db.CentroAcopio, "Id", "Nombre", canjes.CentroAcopioId);
            ViewBag.MaterialId = new SelectList(db.Material, "id", "nombre", canjes.MaterialId);
            ViewBag.ClienteId = new SelectList(db.Usuario, "Email", "Nombre", canjes.ClienteId);
            return View(canjes);
        }

        // GET: Canjes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canjes canjes = db.Canjes.Find(id);
            if (canjes == null)
            {
                return HttpNotFound();
            }
            ViewBag.CentroAcopioId = new SelectList(db.CentroAcopio, "Id", "Nombre", canjes.CentroAcopioId);
            ViewBag.MaterialId = new SelectList(db.Material, "id", "nombre", canjes.MaterialId);
            ViewBag.ClienteId = new SelectList(db.Usuario, "Email", "Nombre", canjes.ClienteId);
            return View(canjes);
        }

        // POST: Canjes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UsuarioId,CentroAcopioId,Cantidad,MaterialId,ClienteId,Fecha")] Canjes canjes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(canjes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CentroAcopioId = new SelectList(db.CentroAcopio, "Id", "Nombre", canjes.CentroAcopioId);
            ViewBag.MaterialId = new SelectList(db.Material, "id", "nombre", canjes.MaterialId);
            ViewBag.ClienteId = new SelectList(db.Usuario, "Email", "Nombre", canjes.ClienteId);
            return View(canjes);
        }

        // GET: Canjes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canjes canjes = db.Canjes.Find(id);
            if (canjes == null)
            {
                return HttpNotFound();
            }
            return View(canjes);
        }

        // POST: Canjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Canjes canjes = db.Canjes.Find(id);
            db.Canjes.Remove(canjes);
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
