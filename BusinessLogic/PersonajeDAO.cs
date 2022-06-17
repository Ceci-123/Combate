using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class PersonajeDAO
    {
        public static Personaje ObtenerPersonajePorId(decimal id)
        {
            string connectionString = @"Server=.\SQLEXPRESS01;Database=COMBATE_DB;Trusted_Connection=True;";

            Personaje personaje = null;

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM PERSONAJES WHERE id = @id";
                command.Parameters.AddWithValue("@id",(int)id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int _id = reader.GetInt32(0);
                    string _nombre = reader.GetString(1);
                    short _nivel = reader.GetInt16(2);
                    short _clase = reader.GetInt16(3);
                    string _titulo = reader.IsDBNull(4)? "" : reader.GetString(4);

                    if(_clase == 1)
                    {
                        personaje = new Guerrero(_id, _nombre, _nivel);
                        personaje.Titulo = _titulo;
                    }
                    else
                    {
                        personaje = new Hechicero(_id, _nombre, _nivel);
                        personaje.Titulo = _titulo;
                    }
                }
                return personaje;
            }
        }
    }
}
