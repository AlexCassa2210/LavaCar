using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDLavacar.Models;

namespace BDLavacar.Controllers
{
    public class ReportesController : Controller
    {
        bdlavacarEntities2 modeloBD = new bdlavacarEntities2();
        #region Vista Principal
        public ActionResult ReportesIndex()
        {
            return View();
        }
        #endregion

        #region Vehículos por cliente
        public ActionResult VehiculosCliente()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ClienteReporteVehiculo()
        {
            List<sp_ReporteVehiculoscliente_Result> listaPersonas =
               this.modeloBD.sp_ReporteVehiculoscliente().ToList();
            return Json(new
            {
                resultado = listaPersonas
            });
        }

        #endregion

        #region Servicios por cliente

        public ActionResult Servicioscliente()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ServiciosclienteLista()
        {
            List<sp_ReporteServicioscliente_Result> listaPersonas =
               this.modeloBD.sp_ReporteServicioscliente().ToList();
            return Json(new
            {
                resultado = listaPersonas
            });
        }

        #endregion

        #region Servicios por vehículo
        public ActionResult ServiciosVehiculo()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ServiciosVehiculoLista()
        {
            List<sp_ReporteServiciosvehiculo_Result> listaPersonas =
               this.modeloBD.sp_ReporteServiciosvehiculo().ToList();
            return Json(new
            {
                resultado = listaPersonas
            });
        }
        #endregion

        #region Servicios por vehículo ID
        public ActionResult ServiciosVehiculoID()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ServiciosVehiculoListaID(string correo)
        {
            correo = Session["correoVista"].ToString();
            List<sp_ReporteServiciosvehiculoID_Result> listaPersonas =
               this.modeloBD.sp_ReporteServiciosvehiculoID(correo).ToList();
            return Json(new
            {
                resultado = listaPersonas
            });
        }
        #endregion

        #region Vehículos por cliente ID
        public ActionResult VehiculosClienteID()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ClienteReporteVehiculoID(string correo)
        {
            correo = Session["correoVista"].ToString();
            List<sp_ReporteVehiculosclienteID_Result> listaPersonas =
               this.modeloBD.sp_ReporteVehiculosclienteID(correo).ToList();
            return Json(new
            {
                resultado = listaPersonas
            });
        }
        #endregion

        #region Servicios por Cliente ID
        public ActionResult ServiciosClienteID()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ServiciosClienteListaID(string correo)
        {
            correo = Session["correoVista"].ToString();
            List<sp_ReporteServiciosclienteID_Result> listaPersonas =
               this.modeloBD.sp_ReporteServiciosclienteID(correo).ToList();
            return Json(new
            {
                resultado = listaPersonas
            });
        }
        #endregion


    }
}