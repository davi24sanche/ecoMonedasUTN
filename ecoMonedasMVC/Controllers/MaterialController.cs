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
    public class MaterialController : Controller
    {
        private EcoContextDB db = new EcoContextDB();

        // GET: Material
        public ActionResult Index()
        {
            var material = db.Material.Include(m => m.Colores);
            return View(material.ToList());
        }

        // GET: Material/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // GET: Material/Create
        public ActionResult Create()
        {
            ViewBag.colorId = new SelectList(db.Colores, "id", "descripcion");
            return View();
        }

        // POST: Material/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,imagen,precioUnidad,colorId")] Material material)
        {
            if (ModelState.IsValid)
            {
                db.Material.Add(material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.colorId = new SelectList(db.Colores, "id", "descripcion", material.colorId);
            return View(material);
        }

        // GET: Material/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            ViewBag.colorId = new SelectList(db.Colores, "id", "descripcion", material.colorId);
            return View(material);
        }

        // POST: Material/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,imagen,precioUnidad,colorId")] Material material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.colorId = new SelectList(db.Colores, "id", "descripcion", material.colorId);
            return View(material);
        }

        // GET: Material/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // POST: Material/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Material material = db.Material.Find(id);
            db.Material.Remove(material);
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
