using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDLavacar.Models;

namespace BDLavacar.Controllers
{
    public class LoginController : Controller
    {

        bdlavacarEntities2 modeloBD = new bdlavacarEntities2();

  
        public ActionResult InicioSesion()
        {
            return View();
        }
        public ActionResult Validar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Validar(string correo, string contra)
        {
            Session["correoVista"] = correo;
            string url = "";
            string mensaje = "";

            try
            {
                sp_RetornaLogueo_Result datosCliente = new sp_RetornaLogueo_Result();
                datosCliente = modeloBD.sp_RetornaLogueo(correo, contra).FirstOrDefault();

                if (datosCliente == null)
                {
                    Response.Write("<script>alert('Datos Invalidos')</script>"); ;
                    this.Session.Add("Nombre", null);
                    this.Session.Add("Tipo", null);
                    this.Session.Add("Fecha", null);
                    this.Session.Add("UsuarioLogeado", false);

                }
                else
                {

                    Session.Add("Nombre" , datosCliente.@Nombre);
                    Session.Add("Tipo",datosCliente.@Tipo);
                    Session.Add("Fecha",datosCliente.@Fecha);
                    Session.Add("UsuarioLogeado",true);

                    if (Convert.ToInt32(this.Session["Tipo"]) == 1)
                    {
                        url = Url.Action("Inicio", "Home");
                      
                    }
                    else if (Convert.ToInt32(this.Session["Tipo"]) == 2)
                    {
                        url = Url.Action("ClientesVistaLista", "ClienteVista");
                     
                    }
                   
                    mensaje = "Usted ha ingresado: " + Session["Nombre"];
                }
            }
            catch (Exception excepcionCapturada)
            {
                mensaje += $"Ocurrio un error:{excepcionCapturada.Message}";
            }

            return Json(new { resultado = mensaje,validado=Session["UsuarioLogeado"],url= url });


        }
    }
}