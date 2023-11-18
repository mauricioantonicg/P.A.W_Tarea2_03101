using System.Web;
using System.Web.Mvc;

namespace CP_ConservarEstados
{
   public class FilterConfig
   {
      public static void RegisterGlobalFilters(GlobalFilterCollection filters)
      {
         filters.Add(new HandleErrorAttribute());
      }
   }
}
