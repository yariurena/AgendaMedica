using System;
using System.Collections.Generic;
using MySqlConnector;

namespace AgendaMedica.DAL
{
    public class PacienteDAL
    {
        public List<AgendaMedica.Modelos.Paciente> ObtenerPacientes()
        {
            List<AgendaMedica.Modelos.Paciente> pacientes = new List<AgendaMedica.Modelos.Paciente>();

            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"SELECT id_paciente, nombre, Primer_apellido, Segundo_apellido, cedula, direccion, email, `FechaNacimiento`, telefono FROM Paciente ORDER BY Primer_apellido, Segundo_apellido, nombre";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                using (MySqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        AgendaMedica.Modelos.Paciente paciente = new AgendaMedica.Modelos.Paciente();

                        paciente.IdPaciente = Convert.ToInt32(lector["id_paciente"]);
                        paciente.Nombre = Convert.ToString(lector["nombre"]) ?? "";
                        paciente.PrimerApellido = Convert.ToString(lector["Primer_apellido"]) ?? "";
                        paciente.SegundoApellido = Convert.ToString(lector["Segundo_apellido"]) ?? "";
                        paciente.Cedula = Convert.ToString(lector["cedula"]) ?? "";
                        paciente.Direccion = Convert.ToString(lector["direccion"]) ?? "";
                        paciente.Email = Convert.ToString(lector["email"]) ?? "";
                        paciente.FechaNacimiento = lector["FechaNacimiento"] == DBNull.Value? (DateTime?)null: Convert.ToDateTime(lector["FechaNacimiento"]);
                        paciente.Telefono = Convert.ToString(lector["telefono"]) ?? "";

                        pacientes.Add(paciente);
                    }
                }
            }
            return pacientes;
        }

        public void InsertarPaciente(AgendaMedica.Modelos.Paciente paciente)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"INSERT INTO Paciente(nombre, Primer_apellido, Segundo_apellido, cedula, direccion, email, FechaNacimiento, telefono) VALUES (@nombre, @primerApellido, @segundoApellido, @cedula, @direccion, @email, @fecha, @telefono)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", paciente.Nombre);
                    comando.Parameters.AddWithValue("@primerApellido", paciente.PrimerApellido);
                    comando.Parameters.AddWithValue("@segundoApellido", paciente.SegundoApellido);
                    comando.Parameters.AddWithValue("@cedula", paciente.Cedula);
                    comando.Parameters.AddWithValue("@direccion", paciente.Direccion);
                    comando.Parameters.AddWithValue("@email", paciente.Email);
                    comando.Parameters.AddWithValue("@fecha", paciente.FechaNacimiento.HasValue? (object)paciente.FechaNacimiento.Value: DBNull.Value);
                    comando.Parameters.AddWithValue("@telefono", paciente.Telefono);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarPaciente(AgendaMedica.Modelos.Paciente paciente)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"UPDATE Paciente SET nombre = @nombre, Primer_apellido = @primerApellido, Segundo_apellido = @segundoApellido, cedula = @cedula, direccion = @direccion, email = @email, FechaNacimiento = @fecha, telefono = @telefono WHERE id_paciente = @idPaciente";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", paciente.Nombre);
                    comando.Parameters.AddWithValue("@primerApellido", paciente.PrimerApellido);
                    comando.Parameters.AddWithValue("@segundoApellido", paciente.SegundoApellido);
                    comando.Parameters.AddWithValue("@cedula", paciente.Cedula);
                    comando.Parameters.AddWithValue("@direccion", paciente.Direccion);
                    comando.Parameters.AddWithValue("@email", paciente.Email);
                    comando.Parameters.AddWithValue("@fecha", paciente.FechaNacimiento.HasValue? (object)paciente.FechaNacimiento.Value: DBNull.Value);
                    comando.Parameters.AddWithValue("@telefono", paciente.Telefono);
                    comando.Parameters.AddWithValue("@idPaciente", paciente.IdPaciente);

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

        public bool ExisteCedula(string cedula, int idPacienteExcluir)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"SELECT COUNT(*) FROM Paciente WHERE cedula = @cedula AND id_paciente <> @idPaciente";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@cedula", cedula);
                    comando.Parameters.AddWithValue("@idPaciente", idPacienteExcluir);

                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());

                    return cantidad > 0;
                }
            }
        }
    }
}
