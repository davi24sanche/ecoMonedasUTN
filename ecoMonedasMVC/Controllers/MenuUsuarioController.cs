using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecoMonedasMVC.Controllers
{
    public class MenuUsuarioController : Controller
    {
        // GET: MenuUsuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Administrador()
        {
            return View();
        }

        public ActionResult AdministradorCentroAcopio() {
            return View();
        }

        public ActionResult Cliente() {
            return View();
        }


    }
}