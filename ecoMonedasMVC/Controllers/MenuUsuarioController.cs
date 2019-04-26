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
        public ActionResult CentroAcopio()
        {
            return Redirect("/CentroAcopio/Index");
        }
        public ActionResult Materiales()
        {
            return Redirect("/Material/Index");
        }
        public ActionResult Usuario()
        {
            return Redirect("/Usuario/Index");
        }
        public ActionResult Cupones()
        {
            return Redirect("/Cupon/Index");
        }
        public ActionResult CambiarContrasenna() {

            return View();

        }

        public ActionResult CerrarSession()
        {
            return Redirect("/");
        }
    }
}