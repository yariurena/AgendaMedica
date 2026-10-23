using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySqlConnector;

namespace AgendaMedica.DAL
{
    public class PacienteDAL
    {
        public DataTable ObtenerPacientes()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"
                    SELECT
                        id_paciente,
                        nombre,
                        apellidos,
                        cedula,
                        direccion,
                        email,
                        `fecha de nacimiento`,
                        telefono
                    FROM Paciente
                    ORDER BY apellidos, nombre";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                {
                    adaptador.Fill(tabla);
                }
            }
            return tabla;
        }
    }
}
