using CE_Entidad;
using CN_Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace CP_ConservarEstados.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         return View();
      }

      //Obtener la lista de encuestas en BD
      public ActionResult RegistroEncuestas()
      {
         return View();
      }

      //Consultar la lista de lenguajes con puntuacion  
      public JsonResult ListaLenguajes()
      {
         List<lenguajeProgramacion> listaLenguajes = new List<lenguajeProgramacion>();

         listaLenguajes = new CNX_ET_LenguajeProgramacion().listaLenguajesProgramacion();


         //Varible de session que almacena la lista de lenguajes y sus puntuaciones 
         Session["listaEncuestas"] = listaLenguajes;

         return Json(new { data = Session["listaEncuestas"] }, JsonRequestBehavior.AllowGet);
      }

      //Registrar una nueva encuesta
      [HttpPost]
      public JsonResult RegistrarNuevaEncuesta( persona datosEncuesta)
      {
         int resultado = 10;
         string mensaje = string.Empty;

         //Validar datos del formulario, si resultado es igual a 10 algun campo esta nulo o vacío
         if (datosEncuesta.nombrePersona == null || datosEncuesta.apellido1 == null || 
            datosEncuesta.idPais == "0" || datosEncuesta.idRolPersona == "0" || 
            datosEncuesta.idLenguajeProgPrimario == "0" || datosEncuesta.idLenguajeProgSecundario == "0") 
         {
            if (datosEncuesta.idLenguajeProgSecundario == "0")
            {
               resultado = 10;
               mensaje = "Seleccione el segundo lenguaje";
            }

            if (datosEncuesta.idLenguajeProgPrimario == "0")
            {
               resultado = 10;
               mensaje = "Seleccione el primer lenguaje";
            }

            if (datosEncuesta.idRolPersona == "0")
            {
               resultado = 10;
               mensaje = "Seleccione el rol de la persona";
            }

            if (datosEncuesta.idPais == "0")
            {
               resultado = 10;
               mensaje = "Seleccione el país";
            }

            if (datosEncuesta.apellido1 == null)
            {
               resultado = 10;
               mensaje = "Ingrese el apellido de la persona";
            }

            if (datosEncuesta.nombrePersona == null)
            {
               resultado = 10;
               mensaje = "Ingrese el nombre de la persona";
            }                                                         
         }
         else
         {
            CNX_ET_Persona registrarNuevaEncuesta = new CNX_ET_Persona();
            resultado = registrarNuevaEncuesta.RegistrarNewEncuestaBD(datosEncuesta);
         }         

         return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet); ;
      }      
   }
}