using ecoMonedasMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecoMonedasMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult InicioSesion()
        {

            return View();

        }

        [HttpPost]
        public ActionResult ValidarUsuario(string email, string password) {

            var db = new EcoContextDB();
            Usuario Usuario = db.Usuario
                                .Where(x => x.Contrasenna.Equals(password))
                                .Where(x => x.Email.Equals(email)).FirstOrDefault();

            if (Usuario != null) {
               return Redirect("/MenuUsuario/Index");
            }

            return View("Index");
        }



    }
}