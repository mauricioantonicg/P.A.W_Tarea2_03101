using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE_Entidad;

namespace CD_Datos
{
   public class CNX_Persona
   {
      //Traer la lista de personas de la tabla personas en la base de datos 
      public List<persona> listaUsuarios()
      {

         //Almacenar la lista de personas de la tabla personas en la base de datos
         List<persona> listaUsuariosBD = new List<persona>();

         try
         {
            //Crear instancia de conexion a la base de datos 
            using (SqlConnection conexionBD = new SqlConnection(BDConexion.conexionBD))
            {
               //String a ejecutar en la base de datos 
               string query = "select * from persona";

               //Crear el envio del sript a ejecutar en la base de datos 
               SqlCommand cmd = new SqlCommand(query, conexionBD);
               cmd.CommandType = CommandType.Text;

               //Abrir conexion con la base de datos
               conexionBD.Open();

               //Ejecutar o enviar el script a la base de datos con la consulta 
               using (SqlDataReader reader = cmd.ExecuteReader())
               {

                  //Leer la respuesta de la base de datos
                  while (reader.Read())
                  {

                     //Crear objeto persona y agregarlo a la lista de personas 
                     listaUsuariosBD.Add(new persona()
                     {
                        idPersona = Convert.ToInt32(reader["idPersona"]),
                        nombrePersona = reader["nombrePersona"].ToString(),
                        apellido1 = reader["apellido1"].ToString(),
                        idPais = reader["idPais"].ToString(),
                        idRolPersona = reader["idRolPersona"].ToString(),
                        idLenguajeProgPrimario = reader["idLenguajeProgPrimario"].ToString(),
                        idLenguajeProgSecundario = reader["idLenguajeProgSecundario"].ToString()
                     });
                  }
               }

            }
         }
         catch (Exception)
         {

            listaUsuariosBD = new List<persona>();
         }

         //Retornar la lista 
         return listaUsuariosBD;
      }

      //Registrar una nueva persona en la tabla persona de la base de datos  
      public int RegistrarPersona(persona person, out string Mensaje)
      {
         int resultado = 0;
         Mensaje = string.Empty;

         try
         {
            //Crear instancia de conexion a la base de datos 
            using (SqlConnection conexionBD = new SqlConnection(BDConexion.conexionBD))
            {
               //Crear el envio del sript a ejecutar en la base de datos 
               SqlCommand cmd = new SqlCommand("sp_RegistrarPersona", conexionBD);
               //Datos de la persona 
               cmd.Parameters.AddWithValue("idPersona", person.idPersona);
               cmd.Parameters.AddWithValue("nombrePersona", person.nombrePersona);
               cmd.Parameters.AddWithValue("apellido1", person.apellido1);
               cmd.Parameters.AddWithValue("idPais", person.idPais);
               cmd.Parameters.AddWithValue("idRolPersona", person.idRolPersona);
               cmd.Parameters.AddWithValue("idLenguajeProgPrimario", person.idLenguajeProgPrimario);
               cmd.Parameters.AddWithValue("idLenguajeProgSecundario", person.idLenguajeProgSecundario);
               cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 300).Direction = ParameterDirection.Output;
               cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
               cmd.CommandType = CommandType.StoredProcedure;

               //Abrir conexion con la base de datos
               conexionBD.Open();

               //Ejecutar o enviar el script a la base de datos con la consulta 
               cmd.ExecuteReader();

               resultado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
               Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
         }
         catch (Exception ex)
         {
            resultado = 0;
            Mensaje = ex.Message;
         }

         //Retornar si se guardo el registro correctamente 
         return resultado;
      }
   }
}
