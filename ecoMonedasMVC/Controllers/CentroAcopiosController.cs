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
    public class CentroAcopiosController : Controller
    {
        private EcoContext db = new EcoContext();

        // GET: CentroAcopios
        public ActionResult Index()
        {
            var centroAcopio = db.CentroAcopio.Include(c => c.Provincias).Include(c => c.Usuario);
            return View(centroAcopio.ToList());
        }

        // GET: CentroAcopios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroAcopio centroAcopio = db.CentroAcopio.Find(id);
            if (centroAcopio == null)
            {
                return HttpNotFound();
            }
            return View(centroAcopio);
        }

        // GET: CentroAcopios/Create
        public ActionResult Create()
        {
            ViewBag.ProvinciaId = new SelectList(db.Provincias, "id", "id");
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Email", "Nombre");
            return View();
        }

        // POST: CentroAcopios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,ProvinciaId,DireccionExacta,UsuarioId")] CentroAcopio centroAcopio)
        {
            if (ModelState.IsValid)
            {
                db.CentroAcopio.Add(centroAcopio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinciaId = new SelectList(db.Provincias, "id", "id", centroAcopio.ProvinciaId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Email", "Nombre", centroAcopio.UsuarioId);
            return View(centroAcopio);
        }

        // GET: CentroAcopios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroAcopio centroAcopio = db.CentroAcopio.Find(id);
            if (centroAcopio == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinciaId = new SelectList(db.Provincias, "id", "id", centroAcopio.ProvinciaId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Email", "Nombre", centroAcopio.UsuarioId);
            return View(centroAcopio);
        }

        // POST: CentroAcopios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,ProvinciaId,DireccionExacta,UsuarioId")] CentroAcopio centroAcopio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(centroAcopio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinciaId = new SelectList(db.Provincias, "id", "id", centroAcopio.ProvinciaId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Email", "Nombre", centroAcopio.UsuarioId);
            return View(centroAcopio);
        }

        // GET: CentroAcopios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroAcopio centroAcopio = db.CentroAcopio.Find(id);
            if (centroAcopio == null)
            {
                return HttpNotFound();
            }
            return View(centroAcopio);
        }

        // POST: CentroAcopios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CentroAcopio centroAcopio = db.CentroAcopio.Find(id);
            db.CentroAcopio.Remove(centroAcopio);
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
