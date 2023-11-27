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

         Session["listaEncuestas"] = listaLenguajes;

         return Json(new { data = Session["listaEncuestas"] }, JsonRequestBehavior.AllowGet);
      }

      //Registrar una nueva encuesta
      [HttpPost]
      public int RegistrarNuevaEncuesta( persona datosEncuesta)
      {
         int resultado;

         CNX_ET_Persona registrarNuevaEncuesta = new CNX_ET_Persona();

         resultado = registrarNuevaEncuesta.RegistrarNewEncuestaBD(datosEncuesta);

         return resultado;
      }      
   }
}