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
         //Traer la lista 
         List<lenguajeProgramacion> listaLenguajesConPorc;
         listaLenguajesConPorc = listaLenguajes.listarLenguajes();

         //int numLeng = listaLenguajesConPorc.Count();
         int numLeng = 0;
         decimal sumPuntTotal = 0;
         decimal puntLengAnt = 0;
         string unDecimal;

         //Sumatoria de puntuaciones 
         foreach (lenguajeProgramacion oLenguaje in listaLenguajesConPorc)
         {
            sumPuntTotal = sumPuntTotal + oLenguaje.puntuacionLenguaje;
         }

         //Calcular los porcentajes de clasificacion y diferencia
         for (int i = 0; i < listaLenguajesConPorc.Count(); i++)
         {
            if (numLeng != 0)
            {
               //Calcular la clasificacion porcentual
               try
               {
                  listaLenguajesConPorc[i].puntuacionLenguaje = listaLenguajesConPorc[i].puntuacionLenguaje / sumPuntTotal * 100;
                  unDecimal = listaLenguajesConPorc[i].puntuacionLenguaje.ToString("0.#");
                  listaLenguajesConPorc[i].puntuacionLenguaje =Convert.ToDecimal(unDecimal);
               }
               catch (Exception)
               {
                  listaLenguajesConPorc[i].puntuacionLenguaje = 0;
               }

               //Calcular la diferencia porcentual
               listaLenguajesConPorc[i-1].diferenciaPuntuacionLenguaje = puntLengAnt - listaLenguajesConPorc[i].puntuacionLenguaje;
               unDecimal = listaLenguajesConPorc[i-1].diferenciaPuntuacionLenguaje.ToString("0.#");
               listaLenguajesConPorc[i-1].diferenciaPuntuacionLenguaje = Convert.ToDecimal(unDecimal);

               //Puntuacion porcentual lenguaje anterior
               puntLengAnt = listaLenguajesConPorc[i].puntuacionLenguaje;
            }
            else
            {
               //Calcular la clasificacion porcentual
               try
               {
                  listaLenguajesConPorc[i].puntuacionLenguaje = listaLenguajesConPorc[i].puntuacionLenguaje / sumPuntTotal * 100;
                  unDecimal = listaLenguajesConPorc[i].puntuacionLenguaje.ToString("0.#");
                  listaLenguajesConPorc[i].puntuacionLenguaje = Convert.ToDecimal(unDecimal);
               }
               catch (Exception)
               {
                  listaLenguajesConPorc[i].puntuacionLenguaje = 0;
               }               

               //Puntuacion  porcentual lenguaje anterior 
               puntLengAnt = listaLenguajesConPorc[i].puntuacionLenguaje;

               //Calcular la diferencia porcentual
               listaLenguajesConPorc[i].diferenciaPuntuacionLenguaje = puntLengAnt;
               unDecimal = listaLenguajesConPorc[i].diferenciaPuntuacionLenguaje.ToString("0.#");
               listaLenguajesConPorc[i].diferenciaPuntuacionLenguaje = Convert.ToDecimal(unDecimal);
            }

            numLeng++;
         }

         return listaLenguajesConPorc;
      }
   }
}
