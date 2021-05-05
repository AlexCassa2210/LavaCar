using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDLavacar.Models;


namespace BDLavacar.Controllers
{
    public class HomeController : Controller
    {
        bdlavacarEntities2 modeloBD = new bdlavacarEntities2();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inicio(string correo)
        {
            sp_RetornaVistaClientes_Result modeloVista = new sp_RetornaVistaClientes_Result();
            correo = Session["correoVista"].ToString();
            modeloVista = modeloBD.sp_RetornaVistaClientes(correo).FirstOrDefault();
            return View(modeloVista);
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
    }
}