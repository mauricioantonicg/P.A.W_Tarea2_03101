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

      public ActionResult Contact()
      {
         return View();
      }
   }
}