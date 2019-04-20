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
    public class BilleteraVirtualsController : Controller
    {
        private EcoContext db = new EcoContext();

        // GET: BilleteraVirtuals
        public ActionResult Index()
        {
            var billeteraVirtual = db.BilleteraVirtual.Include(b => b.Usuario);
            return View(billeteraVirtual.ToList());
        }

        // GET: BilleteraVirtuals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BilleteraVirtual billeteraVirtual = db.BilleteraVirtual.Find(id);
            if (billeteraVirtual == null)
            {
                return HttpNotFound();
            }
            return View(billeteraVirtual);
        }

        // GET: BilleteraVirtuals/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Email", "Nombre");
            return View();
        }

        // POST: BilleteraVirtuals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TotalMonedasDisponibles,TotalMonedasCanjeadas,TotalMonedasGeneradas,UsuarioId")] BilleteraVirtual billeteraVirtual)
        {
            if (ModelState.IsValid)
            {
                db.BilleteraVirtual.Add(billeteraVirtual);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.Usuario, "Email", "Nombre", billeteraVirtual.UsuarioId);
            return View(billeteraVirtual);
        }

        // GET: BilleteraVirtuals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BilleteraVirtual billeteraVirtual = db.BilleteraVirtual.Find(id);
            if (billeteraVirtual == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Email", "Nombre", billeteraVirtual.UsuarioId);
            return View(billeteraVirtual);
        }

        // POST: BilleteraVirtuals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TotalMonedasDisponibles,TotalMonedasCanjeadas,TotalMonedasGeneradas,UsuarioId")] BilleteraVirtual billeteraVirtual)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billeteraVirtual).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Email", "Nombre", billeteraVirtual.UsuarioId);
            return View(billeteraVirtual);
        }

        // GET: BilleteraVirtuals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BilleteraVirtual billeteraVirtual = db.BilleteraVirtual.Find(id);
            if (billeteraVirtual == null)
            {
                return HttpNotFound();
            }
            return View(billeteraVirtual);
        }

        // POST: BilleteraVirtuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BilleteraVirtual billeteraVirtual = db.BilleteraVirtual.Find(id);
            db.BilleteraVirtual.Remove(billeteraVirtual);
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
