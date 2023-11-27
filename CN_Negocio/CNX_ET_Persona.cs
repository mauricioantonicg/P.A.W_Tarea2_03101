using CD_Datos;
using CE_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Negocio
{
   public class CNX_ET_Persona
   {
      //Instancia de la clase persona donde se registra la encuesta 
      CNX_Persona person = new CNX_Persona();

      public int RegistrarNewEncuestaBD(persona personaa) {

         int resultado;
         decimal nuevaPuntLengPrima = 0;
         decimal nuevaPuntLengSecun = 0;

         string unDecimal;

         //Almacenar datos de una nueva encuesta en base de datos
         resultado = person.RegistrarNuevaEncuesta(personaa);

         //Agregar puntuacion a los lenguajes, si resultado es 1 se alamcenaron los datos de la nueva encuesta y
         //Se debe incremetar el puntaje de 2 lenguajes de programacion 
         if (resultado == 1) {

            //Consultar la puntuacion actual de cada lenguaje e incrementarlo (+1 lenguaje primario, +0.5 secundario)
            nuevaPuntLengPrima = person.ConsultarPuntuacionLenguaje(personaa.idLenguajeProgPrimario) + 1;
            unDecimal = nuevaPuntLengPrima.ToString("0.#");
            nuevaPuntLengPrima = Convert.ToDecimal(unDecimal);
            unDecimal = "0";

            nuevaPuntLengSecun = person.ConsultarPuntuacionLenguaje(personaa.idLenguajeProgSecundario) + 0.5m;
            unDecimal = nuevaPuntLengSecun.ToString("0.#");
            nuevaPuntLengSecun = Convert.ToDecimal(unDecimal);


            //Si falla la consulta a la base de datos sobre las puntuaciones actuales se asigna el numero 2
            if (nuevaPuntLengPrima != -1 && nuevaPuntLengSecun != -1 )
            {
               //Actualizar la puntuacion del lenguaje 1
               resultado = person.IncrementarPuntuacionLenguaje(personaa.idLenguajeProgPrimario, nuevaPuntLengPrima);

               //Se asigna el numero 3 al resultado si falla la actualizacion de la puntuacion lenguaje primario
               if (resultado == -1) {
                  resultado = 3;
               }else
               {
                  //Actualizar la puntuacion del lenguaje 2
                  resultado = person.IncrementarPuntuacionLenguaje(personaa.idLenguajeProgSecundario, nuevaPuntLengSecun);

                  //Se asigna el numero 4 al resultado si falla la actualizacion de la puntuacion lenguaje secundario
                  if (resultado == -1)
                  {
                     resultado = 4;
                  }
               }
            }
            else
            {
               //Se asigna el numero 2 a la variable resultado indicando que se almaceno la nueva encuesta pero
               //fallo la consulta de puntucion de los lenguajes y por lo tanto no se pudo incrementar sus puntuaciones  
               resultado = 2;
            }      
         }

         return resultado;      
      }
   }
}
