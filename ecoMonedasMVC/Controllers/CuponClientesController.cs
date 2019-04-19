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
    public class CuponClientesController : Controller
    {
        private EcoContext db = new EcoContext();

        // GET: CuponClientes
        public ActionResult Index()
        {
            var cuponCliente = db.CuponCliente.Include(c => c.Cupon).Include(c => c.Usuario);
            return View(cuponCliente.ToList());
        }

        // GET: CuponClientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuponCliente cuponCliente = db.CuponCliente.Find(id);
            if (cuponCliente == null)
            {
                return HttpNotFound();
            }
            return View(cuponCliente);
        }

        // GET: CuponClientes/Create
        public ActionResult Create()
        {
            ViewBag.CuponId = new SelectList(db.Cupon, "Id", "Nombre");
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Email", "Nombre");
            return View();
        }

        // POST: CuponClientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UsuarioId,CuponId")] CuponCliente cuponCliente)
        {
            if (ModelState.IsValid)
            {
                db.CuponCliente.Add(cuponCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CuponId = new SelectList(db.Cupon, "Id", "Nombre", cuponCliente.CuponId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Email", "Nombre", cuponCliente.UsuarioId);
            return View(cuponCliente);
        }

        // GET: CuponClientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuponCliente cuponCliente = db.CuponCliente.Find(id);
            if (cuponCliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.CuponId = new SelectList(db.Cupon, "Id", "Nombre", cuponCliente.CuponId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Email", "Nombre", cuponCliente.UsuarioId);
            return View(cuponCliente);
        }

        // POST: CuponClientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UsuarioId,CuponId")] CuponCliente cuponCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuponCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CuponId = new SelectList(db.Cupon, "Id", "Nombre", cuponCliente.CuponId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Email", "Nombre", cuponCliente.UsuarioId);
            return View(cuponCliente);
        }

        // GET: CuponClientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuponCliente cuponCliente = db.CuponCliente.Find(id);
            if (cuponCliente == null)
            {
                return HttpNotFound();
            }
            return View(cuponCliente);
        }

        // POST: CuponClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CuponCliente cuponCliente = db.CuponCliente.Find(id);
            db.CuponCliente.Remove(cuponCliente);
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
