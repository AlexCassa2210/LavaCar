using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDLavacar.Models;

namespace BDLavacar.Controllers
{
    public class VehiculoController : Controller
    {
        bdlavacarEntities2 modeloBD = new bdlavacarEntities2();
        // GET: Vehiculo
        public ActionResult Index()
        {
            return View();
        }

        #region Void
        void AgregaPaisFabricacionViewBag()
        {
            this.ViewBag.ListaPaises = this.modeloBD.sp_RetornaPaisFabricante("", "").ToList();
        }
        void AgregaMarcaVehiculoViewBag()
        {
            this.ViewBag.ListaMarcas = this.modeloBD.sp_RetornaMarcaVehiculo("", "").ToList();
        }
        void AgregaTipoVehiculoViewBag()
        {
            this.ViewBag.ListaTipos = this.modeloBD.sp_RetornaTipoVehiculo("", "").ToList();
        }
        #endregion

        #region Retorna
        /// <summary>
        /// Método para mostrar la lista de los paises de fabricación
        /// </summary>
        /// <returns></returns>
        public ActionResult PaisFabricanteLista()
        {
            List<sp_RetornaPaisFabricante_Result> lista = new List<sp_RetornaPaisFabricante_Result>();

            lista = modeloBD.sp_RetornaPaisFabricante("","").ToList();
            return View(lista);
        }


        /// <summary>
        /// Método para mostrar la lista de las marcas de los vehículos
        /// </summary>
        /// <returns></returns>
        public ActionResult MarcaVehiculoLista()
        {
            List<sp_RetornaMarcaVehiculo_Result> lista = new List<sp_RetornaMarcaVehiculo_Result>();

            lista = modeloBD.sp_RetornaMarcaVehiculo("", "").ToList();
            return View(lista);
        }


        /// <summary>
        /// Método para mostrar la lista de los tipos de vehículos
        /// </summary>
        /// <returns></returns>
        public ActionResult TipoVehiculoLista()
        {
            List<sp_RetornaTipoVehiculo_Result> lista = new List<sp_RetornaTipoVehiculo_Result>();

            lista = modeloBD.sp_RetornaTipoVehiculo("", "").ToList();
            return View(lista);
        }

        /// <summary>
        /// Método para mostrar la lista de los vehículos
        /// </summary>
        /// <returns></returns>
        public ActionResult VehiculoLista()
        {
            List<sp_RetornaVehiculo_Result> lista = new List<sp_RetornaVehiculo_Result>();

            lista = modeloBD.sp_RetornaVehiculo("").ToList();
            return View(lista);
        }

        #endregion

        #region Inserta
        public ActionResult PaisFabricanteNuevo()
        {
            return View();
        }

        /// <summary>
        /// Método para insertar registros del Pais de Fabricación
        /// </summary>
        /// <param name="modeloVista"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PaisFabricanteNuevo(sp_RetornaPaisFabricante_Result modeloVista)
        {
            int registros = 0;
            string mensaje = "";

            try
            {
                registros = modeloBD.sp_InsertaPaisFabricante(
                    modeloVista.Pais_PF,
                    modeloVista.Codigo_PF
                    );
            }
            catch (Exception e)
            {
                mensaje = "Ocurrió un error: " + e.Message;
            }
            finally
            {
                if (registros > 0)
                {
                    mensaje = "Registro insertado.";
                }
                else
                {
                    mensaje = "No se pudo insertar.";
                }
            }

            Response.Write("<script laguage=JavaScript>alert('" + mensaje + "');</script>");
            return View();
        }

        public ActionResult TipoVehiculoNuevo()
        {
            return View();
        }
        /// <summary>
        /// Método para insertar registros del Tipo de Vehículo
        /// </summary>
        /// <param name="modeloVista"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TipoVehiculoNuevo(sp_RetornaTipoVehiculo_Result modeloVista)
        {
            int registros = 0;
            string mensaje = "";

            try
            {
                registros = modeloBD.sp_InsertaTipoVehiculo(
                    modeloVista.Tipo_TV,
                    modeloVista.codigo_TV
                    );
            }
            catch (Exception e)
            {
                mensaje = "Ocurrió un error: " + e.Message;
            }
            finally
            {
                if (registros > 0)
                {
                    mensaje = "Registro insertado.";
                }
                else
                {
                    mensaje = "No se pudo insertar.";
                }
            }

            Response.Write("<script laguage=JavaScript>alert('" + mensaje + "');</script>");
            return View();
        }

        public ActionResult MarcaVehiculoNuevo()
        {
            AgregaPaisFabricacionViewBag();
            return View();
        }

        /// <summary>
        /// Método para insertar registros de la marcas de los vehículos.
        /// </summary>
        /// <param name="modeloVista"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MarcaVehiculoNuevo(sp_RetornaMarcaVehiculo_Result modeloVista)
        {
            int registros = 0;
            string mensaje = "";

            try
            {
                registros = modeloBD.sp_InsertaMarcaVehiculo(
                    modeloVista.Tipo_MV,
                    modeloVista.Codigo_MV,
                    modeloVista.Id_PaisFabricacion_PF
                    );
            }
            catch (Exception e)
            {
                mensaje = "Ocurrió un error: " + e.Message;
            }
            finally
            {
                if (registros > 0)
                {
                    mensaje = "Registro insertado.";
                }
                else
                {
                    mensaje = "No se pudo insertar.";
                }
            }

            Response.Write("<script laguage=JavaScript>alert('" + mensaje + "');</script>");
            AgregaPaisFabricacionViewBag();
            return View();
        }


        public ActionResult VehiculoNuevo()
        {
            AgregaMarcaVehiculoViewBag();
            AgregaTipoVehiculoViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult VehiculoNuevo(sp_RetornaVehiculo_Result modeloVista)
        {
            int registros = 0;
            string mensaje = "";

            try
            {
                registros = modeloBD.sp_InsertaVehiculo(
                    modeloVista.Placa_V,
                    modeloVista.Id_Marca_V,
                    modeloVista.Id_Tipo_V,
                    modeloVista.Numero_Puertas_V,
                    modeloVista.Numero_Ruedas_V
                    );
            }
            catch (Exception e)
            {
                mensaje = "Ocurrió un error: " + e.Message;
            }
            finally
            {
                if (registros > 0)
                {
                    mensaje = "Registro insertado.";
                }
                else
                {
                    mensaje = "No se pudo insertar.";
                }
            }

            Response.Write("<script laguage=JavaScript>alert('" + mensaje + "');</script>");
            AgregaMarcaVehiculoViewBag();
            AgregaTipoVehiculoViewBag();
            return View();
        }

        #endregion

        #region Elimina

        public ActionResult PaisFabricanteElimina(int id_PaisFabricacion_PF)
        {
            sp_RetornaPaisFabricante_ID_Result modeloVista = new sp_RetornaPaisFabricante_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaPaisFabricante_ID(id_PaisFabricacion_PF).FirstOrDefault();
            return View(modeloVista);
        }
        [HttpPost]
        public ActionResult PaisFabricanteElimina(sp_RetornaPaisFabricante_ID_Result modeloVista)
        {
            int regitros = 0;
            string resultado = "";

            try
            {
                regitros = this.modeloBD.sp_EliminaPaisFabricante(modeloVista.Id_PaisFabricacion_PF);
            }
            catch (Exception error)
            {

                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                if (regitros > 0)
                {
                    resultado = "Registro eliminado";
                }
                else
                {
                    resultado = "No se pudo eliminar";
                }
            }
            Response.Write("<script laguage=JavaScript>alert('" + resultado + "');</script>");
            return View(modeloVista);
        }


        public ActionResult MarcaVehiculoElimina(int id_Marca_MV)
        {
            sp_RetornaMarcaVehiculo_ID_Result modeloVista = new sp_RetornaMarcaVehiculo_ID_Result();
            modeloVista = modeloBD.sp_RetornaMarcaVehiculo_ID(id_Marca_MV).FirstOrDefault();
            AgregaPaisFabricacionViewBag();
            return View(modeloVista);
        }
        [HttpPost]
        public ActionResult MarcaVehiculoElimina(sp_RetornaMarcaVehiculo_ID_Result modeloVista)
        {
            int regitros = 0;
            string resultado = "";

            try
            {
                regitros = this.modeloBD.sp_EliminaMarcaVehiculo(modeloVista.Id_Marca_MV);
            }
            catch (Exception error)
            {

                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                if (regitros > 0)
                {
                    resultado = "Registro eliminado";
                }
                else
                {
                    resultado = "No se pudo eliminar";
                }
            }
            Response.Write("<script laguage=JavaScript>alert('" + resultado + "');</script>");
            AgregaPaisFabricacionViewBag();
            return View(modeloVista);
        }


        public ActionResult TipoVehiculoElimina(int id_Tipo_TV)
        {
            sp_RetornaTipoVehiculo_ID_Result modeloVista = new sp_RetornaTipoVehiculo_ID_Result();
            modeloVista = modeloBD.sp_RetornaTipoVehiculo_ID(id_Tipo_TV).FirstOrDefault();
            return View(modeloVista);
        }
        [HttpPost]
        public ActionResult TipoVehiculoElimina(sp_RetornaTipoVehiculo_ID_Result modeloVista)
        {
            int regitros = 0;
            string resultado = "";

            try
            {
                regitros = this.modeloBD.sp_EliminaTipoVehiculo(modeloVista.Id_Tipo_TV);
            }
            catch (Exception error)
            {

                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                if (regitros > 0)
                {
                    resultado = "Registro eliminado";
                }
                else
                {
                    resultado = "No se pudo eliminar";
                }
            }
            Response.Write("<script laguage=JavaScript>alert('" + resultado + "');</script>");
            return View(modeloVista);
            //Response.Redirect("~/Vehiculo/TipoVehiculoLista");
        }


        public ActionResult VehiculoElimina(int id_Vehiculo_V)
        {
            sp_RetornaVehiculo_ID_Result modeloVista = new sp_RetornaVehiculo_ID_Result();
            modeloVista = modeloBD.sp_RetornaVehiculo_ID(id_Vehiculo_V).FirstOrDefault();
            AgregaMarcaVehiculoViewBag();
            AgregaTipoVehiculoViewBag();
            return View(modeloVista);
        }
        [HttpPost]
        public ActionResult VehiculoElimina(sp_RetornaVehiculo_ID_Result modeloVista)
        {
            int regitros = 0;
            string resultado = "";

            try
            {
                regitros = this.modeloBD.sp_EliminaVehiculo(modeloVista.Id_Vehiculo_V);
            }
            catch (Exception error)
            {

                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                if (regitros > 0)
                {
                    resultado = "Registro eliminado";
                }
                else
                {
                    resultado = "No se pudo eliminar";
                }
            }
            Response.Write("<script laguage=JavaScript>alert('" + resultado + "');</script>");
            AgregaMarcaVehiculoViewBag();
            AgregaTipoVehiculoViewBag();
            return View(modeloVista);
            //Response.Redirect("~/Vehiculo/TipoVehiculoLista");
        }
        #endregion

        #region Modifica
        public ActionResult PaisFabricanteModifica(int id_PaisFabricacion_PF)
        {
            sp_RetornaPaisFabricante_ID_Result modeloVista = new sp_RetornaPaisFabricante_ID_Result();
            modeloVista = this.modeloBD.sp_RetornaPaisFabricante_ID(id_PaisFabricacion_PF).FirstOrDefault();
            return View(modeloVista);
        }
        [HttpPost]
        public ActionResult PaisFabricanteModifica(sp_RetornaPaisFabricante_ID_Result modeloVista)
        {
            int regitros = 0;
            string resultado = "";

            try
            {
                regitros = this.modeloBD.sp_ModificaPaisFabricante(
                    modeloVista.Id_PaisFabricacion_PF,
                    modeloVista.Codigo_PF,
                    modeloVista.Pais_PF
                    );
            }
            catch (Exception error)
            {

                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                if (regitros > 0)
                {
                    resultado = "Registro modificado";
                }
                else
                {
                    resultado = "No se pudo modificar";
                }
            }
            Response.Write("<script laguage=JavaScript>alert('" + resultado + "');</script>");
            return View(modeloVista);
        }


        public ActionResult MarcaVehiculoModifica(int id_Marca_MV)
        {
            sp_RetornaMarcaVehiculo_ID_Result modeloVista = new sp_RetornaMarcaVehiculo_ID_Result();
            modeloVista = modeloBD.sp_RetornaMarcaVehiculo_ID(id_Marca_MV).FirstOrDefault();
            AgregaPaisFabricacionViewBag();
            return View(modeloVista);
        }
        [HttpPost]
        public ActionResult MarcaVehiculoModifica(sp_RetornaMarcaVehiculo_ID_Result modeloVista)
        {
            int regitros = 0;
            string resultado = "";

            try
            {
                regitros = this.modeloBD.sp_ModificaMarcaVehiculo(
                    modeloVista.Id_Marca_MV,
                    modeloVista.Id_PaisFabricacion_PF,
                    modeloVista.Tipo_MV,
                    modeloVista.Codigo_MV
                    );
            }
            catch (Exception error)
            {

                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                if (regitros > 0)
                {
                    resultado = "Registro modificado";
                }
                else
                {
                    resultado = "No se pudo modificar";
                }
            }
            Response.Write("<script laguage=JavaScript>alert('" + resultado + "');</script>");
            AgregaPaisFabricacionViewBag();
            return View(modeloVista);
        }


        public ActionResult TipoVehiculoModifica(int id_Tipo_TV)
        {
            sp_RetornaTipoVehiculo_ID_Result modeloVista = new sp_RetornaTipoVehiculo_ID_Result();
            modeloVista = modeloBD.sp_RetornaTipoVehiculo_ID(id_Tipo_TV).FirstOrDefault();
            return View(modeloVista);
        }
        [HttpPost]
        public ActionResult TipoVehiculoModifica(sp_RetornaTipoVehiculo_ID_Result modeloVista)
        {
            int regitros = 0;
            string resultado = "";

            try
            {
                regitros = this.modeloBD.sp_ModificaTipoVehiculo(
                    modeloVista.Id_Tipo_TV,
                    modeloVista.Tipo_TV,
                    modeloVista.codigo_TV);
            }
            catch (Exception error)
            {

                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                if (regitros > 0)
                {
                    resultado = "Registro modificado";
                }
                else
                {
                    resultado = "No se pudo modificar";
                }
            }
            Response.Write("<script laguage=JavaScript>alert('" + resultado + "');</script>");
            return View(modeloVista);
            //Response.Redirect("~/Vehiculo/TipoVehiculoLista");
        }


        public ActionResult VehiculoModifica(int id_Vehiculo_V)
        {
            sp_RetornaVehiculo_ID_Result modeloVista = new sp_RetornaVehiculo_ID_Result();
            modeloVista = modeloBD.sp_RetornaVehiculo_ID(id_Vehiculo_V).FirstOrDefault();
            AgregaMarcaVehiculoViewBag();
            AgregaTipoVehiculoViewBag();
            return View(modeloVista);
        }
        [HttpPost]
        public ActionResult VehiculoModifica(sp_RetornaVehiculo_ID_Result modeloVista)
        {
            int regitros = 0;
            string resultado = "";

            try
            {
                regitros = this.modeloBD.sp_ModificaVehiculo(
                    modeloVista.Id_Vehiculo_V,
                    modeloVista.Placa_V,
                    modeloVista.Id_Marca_MV,
                    modeloVista.Id_Tipo_TV,
                    modeloVista.Numero_Puertas_V,
                    modeloVista.Numero_Ruedas_V);
            }
            catch (Exception error)
            {

                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                if (regitros > 0)
                {
                    resultado = "Registro modificado";
                }
                else
                {
                    resultado = "No se pudo modificar";
                }
            }
            Response.Write("<script laguage=JavaScript>alert('" + resultado + "');</script>");
            AgregaMarcaVehiculoViewBag();
            AgregaTipoVehiculoViewBag();
            return View(modeloVista);
            //Response.Redirect("~/Vehiculo/TipoVehiculoLista");
        }
        #endregion
    }
}