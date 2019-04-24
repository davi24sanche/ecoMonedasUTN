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
        //GET: MenuUsuario/Administrador
        public ActionResult Administrador()
        {
            return View();
        }
        //GET: MenuUsuario/AdministradorCentroAcopio
        public ActionResult AdministradorCentroAcopio() {
            return View();
        }
        //GET: MenuUsuario/Cliente
        public ActionResult Cliente() {
            return View();
        }


    }
}