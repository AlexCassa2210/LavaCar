using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDLavacar.Models;

namespace BDLavacar.Controllers
{
    public class ServiciosController : Controller
    {
        bdlavacarEntities2 modeloBD = new bdlavacarEntities2();



        #region Insertar
        public ActionResult InsertarServicio()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertarServicio(sp_RetornaServicios_Result modeloVista)
        {
            int cantRegistroAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistroAfectados = this.modeloBD.sp_InsertaServicio(
                                        modeloVista.Codigo_S,
                                        modeloVista.Descripcion_S,
                                        modeloVista.Precio_S,
                                        modeloVista.Tipo_S
                                        );
            }
            catch (Exception error)
            {
                resultado = "Ocurrio un error: " + error.Message;
            }
            finally
            {
                if (cantRegistroAfectados > 0)
                {
                    resultado += "Registro Insertado";
                }
                else
                {
                    resultado += "No se pudo insertar";
                }
            }

            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");

            
            return View();
        }

        #endregion

        #region Listar
        public ActionResult ServicioLista()
        {
            List<sp_RetornaServicios_Result> modeloVista =
                new List<sp_RetornaServicios_Result>();

            modeloVista = modeloBD.sp_RetornaServicios().ToList();
            return View(modeloVista);
        }
        #endregion

        #region Modificar
        public ActionResult ServicioModifica(int Id_Servicio_S)
        {
            sp_RetornaServicioID_Result modelovista = new sp_RetornaServicioID_Result();
            modelovista = this.modeloBD.sp_RetornaServicioID(Id_Servicio_S).FirstOrDefault();
            return View(modelovista);
        }

        [HttpPost]
        public ActionResult ServicioModifica(sp_RetornaServicioID_Result modelovista)
        {
            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados = this.modeloBD.sp_ModificaServicio(
                    modelovista.Id_Servicio_S,
                    modelovista.Codigo_S,
                    modelovista.Descripcion_S,
                    modelovista.Precio_S,
                    modelovista.Tipo_S
                   


                    );
            }
            catch (Exception error)
            {
                resultado = "Ocurrio un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado += "Registro modificado";
                }
                else
                {
                    resultado += "No se pudo modificar";
                }

            }
            Response.Write("<script language=javascript>alert('" + resultado + "')</script>");
            return View(modelovista);


        }

        #endregion

        #region Eliminar
        public ActionResult ServicioEliminar(int Id_Servicio_S)
        {
            sp_RetornaServicioID_Result modelovista = new sp_RetornaServicioID_Result();
            modelovista = this.modeloBD.sp_RetornaServicioID(Id_Servicio_S).FirstOrDefault();
            return View(modelovista);
        }

        [HttpPost]
        public ActionResult ServicioEliminar(sp_RetornaServicioID_Result modelovista)
        {
            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados = this.modeloBD.sp_EliminaServicio(
                    modelovista.Id_Servicio_S);
            }
            catch (Exception error)
            {
                resultado = "Ocurrio un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado += "Registro Eliminado";
                }
                else
                {
                    resultado += "No se pudo Eliminado";
                }

            }
            Response.Write("<script language=javascript>alert('" + resultado + "')</script>");

            return View(modelovista);


        }
        #endregion

    }
}