using CE_Entidad;
using CN_Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP_ConservarEstados.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         return View();
      }

      public ActionResult RegistroEncuestas()
      {
         return View();
      }

      //Consultar la lista de lenguajes con puntuacion  
      public JsonResult ListaLenguajes()
      {
         List<lenguajeProgramacion> listaLenguajes = new List<lenguajeProgramacion>();

         listaLenguajes = new CNX_ET_LenguajeProgramacion().listaLenguajesProgramacion();

         return Json( new { data = listaLenguajes } , JsonRequestBehavior.AllowGet);
      }
   }
}