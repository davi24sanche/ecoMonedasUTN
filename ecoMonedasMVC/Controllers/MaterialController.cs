using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
            ViewBag.Mensaje = TempData["Mensaje"];
            var material = db.Material.Include(m => m.Colores);
            return View(material.ToList());
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
        public ActionResult Create(Material material, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null) {

                    string path = Server.MapPath("~/Content/Imagenes/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    upload.SaveAs(path + Path.GetFileName(upload.FileName));
                    material.imagen = upload.FileName;
                }

                db.Material.Add(material);
                TempData["Mensaje"] = "Material Creado Correctamente";
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
                return View("Error");
            }
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return View("Error");
            }
            ViewBag.colorId = new SelectList(db.Colores, "id", "descripcion", material.colorId);
            return View(material);
        }

        // POST: Material/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Material material, HttpPostedFileBase archivo)
        {
            if (ModelState.IsValid)
            {
                if (archivo != null)
                {

                    string path = Server.MapPath("~/Content/Imagenes/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    archivo.SaveAs(path + Path.GetFileName(archivo.FileName));
                    material.imagen = archivo.FileName;
                }



                db.Entry(material).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensaje"] = "Material Actualizado!!!";
                return RedirectToAction("Index");
            }
            ViewBag.colorId = new SelectList(db.Colores, "id", "descripcion", material.colorId);
            return View(material);
        }
        
        public ActionResult Error() {
            return View();
        }
        public ActionResult VolverAlPanelUsuario()
        {
            return Redirect("/MenuUsuario/Administrador");
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
