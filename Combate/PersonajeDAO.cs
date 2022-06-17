using System;
using System.Data.SqlClient;

namespace CombateApp
{
    public static class PersonajeDAO
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;

        static PersonajeDAO()
        {
            connectionString = @"Data Source=.;Initial Catalog=COMBATE_DB;Integrated Security=True";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }
        public static Personaje ObtenerPersonajePorId(decimal id)
        {
            Personaje personaje = null;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM PERSONAJES WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", id);

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int _id = dataReader.GetInt32(0);
                        string _nombre = dataReader.GetString(1);
                        short _nivel = dataReader.GetInt16(2);
                        short _clase = dataReader.GetInt16(3);
                        string _titulo = dataReader.IsDBNull(4) ? "" : dataReader.GetString(4);

                        if ((Convert.ToInt32(dataReader["CLASE"]) == 1))
                        {
                            personaje = new Guerrero(_id, _nivel, _nombre);
                            personaje.Titulo = _titulo;
                        }
                        if ((Convert.ToInt32(dataReader["CLASE"]) == 2))
                        {
                            personaje = new Hechicero(_id, _nivel, _nombre);
                            personaje.Titulo = _titulo;
                        }
                    }
                }

                return personaje;
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }

            return personaje;
        }
    }
}
