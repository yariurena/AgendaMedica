using MySqlConnector;
using System;

namespace AgendaMedica.DAL
{
    public class ConexionBD
    {
        private const string CadenaConexion =
            "Server=localhost;Port=3306;Database=agenda_medica;User ID=root;Password=*A123456789*;";

        public static MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public static string ProbarConexion()
        {
            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    return "¡Conexión con MySQL correcta!";
                }
            }
            catch (Exception ex)
            {
                return "Error de conexión: " + ex.Message;
            }
        }
    }
}
