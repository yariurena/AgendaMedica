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
                        `FechaNacimiento`,
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

        public void InsertarPaciente(Paciente paciente)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                string consulta = @"
                INSERT INTO Paciente
                (nombre, apellidos, cedula, direccion, email,
                FechaNacimiento, telefono)
                VALUES
                (@nombre, @apellidos, @cedula, @direccion, @email,
                @fecha, @telefono)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", paciente.Nombre);
                    comando.Parameters.AddWithValue("@apellidos", paciente.Apellidos);
                    comando.Parameters.AddWithValue("@cedula", paciente.Cedula);
                    comando.Parameters.AddWithValue("@direccion", paciente.Direccion);
                    comando.Parameters.AddWithValue("@email", paciente.Email);

                    comando.Parameters.AddWithValue("@fecha", paciente.FechaNacimiento.HasValue ? (object)paciente.FechaNacimiento.Value : DBNull.Value);
                    comando.Parameters.AddWithValue("@telefono", paciente.Telefono);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public bool ExisteCedula(string cedula)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();
                string consulta = "SELECT COUNT(*) FROM Paciente WHERE cedula = @cedula";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@cedula", cedula);
                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());

                    return cantidad > 0;
                }
            }
        }
    }
}
