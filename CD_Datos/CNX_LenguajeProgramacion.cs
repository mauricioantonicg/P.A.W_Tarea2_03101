using CE_Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_Datos
{
   public class CNX_LenguajeProgramacion
   {
      //Traer la lista de lenguajes de la base de datos 
      public List<lenguajeProgramacion> listarLenguajes()
      {

         //Almacenar la lista de lenguajes
         List<lenguajeProgramacion> listaLenguajesBD = new List<lenguajeProgramacion>();

         try
         {
            //Crear instancia de conexion a la base de datos 
            using (SqlConnection conexionBD = new SqlConnection(BDConexion.conexionBD))
            {
               //String a ejecutar en la base de datos 
               string query = "select * from lenguajeProgramacion order by puntuacionLenguaje desc";

               //Crear el envio del sript a ejecutar en la base de datos 
               SqlCommand cmd = new SqlCommand(query, conexionBD);
               cmd.CommandType = CommandType.Text;

               //Abrir conexion con la base de datos
               conexionBD.Open();

               int contador = 1;

               //Ejecutar o enviar el script a la base de datos con la consulta 
               using (SqlDataReader reader = cmd.ExecuteReader())
               {


                  //Leer la respuesta de la base de datos
                  while (reader.Read())
                  {

                     //Crear objeto lenguajeProgramacion 
                     listaLenguajesBD.Add(new lenguajeProgramacion()
                     {
                        idLenguajeProgram = contador++,
                        nombreLenguajeProgram = reader["nombreLenguajeProgram"].ToString(),
                        puntuacionLenguaje = Convert.ToDecimal(reader["puntuacionLenguaje"]),
                     }); 
                  }
               }

            }
         }
         catch (Exception)
         {

            listaLenguajesBD = new List<lenguajeProgramacion>();
         }

         //Retornar la lista 
         return listaLenguajesBD;
      }
   }
}
