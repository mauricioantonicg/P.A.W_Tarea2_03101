using CD_Datos;
using CE_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Negocio
{
   public class CNX_ET_LenguajeProgramacion
   {
      //Crear instancia de la clase lenguajesProgramacion 
      private CNX_LenguajeProgramacion listaLenguajes = new CNX_LenguajeProgramacion();

      //Consultar la lista de lenguajes y puntuacion en la base de datos
      public List<lenguajeProgramacion> listaLenguajesProgramacion()
      {
         return listaLenguajes.listarLenguajes();
      }
   }
}
