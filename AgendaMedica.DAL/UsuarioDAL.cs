using System;
using System.Collections.Generic;
using AgendaMedica.Modelos;
using MySqlConnector;

namespace AgendaMedica.DAL
{
    public class UsuarioDAL
    {
        public int ContarUsuarios()
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                using (MySqlCommand comando = new MySqlCommand("SELECT COUNT(*) FROM Usuario", conexion))
                {
                    return Convert.ToInt32(comando.ExecuteScalar());
                }
            }
        }

        public Usuario? ObtenerPorEmail(string email)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = "SELECT u.id_usuario, u.Nombre, u.Primer_apellido, u.Segundo_apellido, u.Email, u.Contrasena, u.id_rol, r.Nombre AS Rol " + "FROM Usuario u " + "INNER JOIN Rol r ON u.id_rol = r.id_rol " + "WHERE u.Email = @email";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@email", email);

                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            return LeerUsuario(lector, true);
                        }
                    }
                }
            }
            return null;
        }

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = "SELECT u.id_usuario, u.Nombre, u.Primer_apellido, u.Segundo_apellido, u.Email, u.id_rol, r.Nombre AS Rol " + "FROM Usuario u " + "INNER JOIN Rol r ON u.id_rol = r.id_rol " + "ORDER BY u.Primer_apellido, u.Segundo_apellido, u.Nombre";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                using (MySqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        usuarios.Add(LeerUsuario(lector, false));
                    }
                }
            }
            return usuarios;
        }

        private Usuario LeerUsuario(MySqlDataReader lector, bool incluirContrasena)
        {
            Usuario usuario = new Usuario();

            usuario.IdUsuario = Convert.ToInt32(lector["id_usuario"]);
            usuario.Nombre = Convert.ToString(lector["Nombre"]) ?? "";
            usuario.PrimerApellido = Convert.ToString(lector["Primer_apellido"]) ?? "";
            usuario.SegundoApellido = Convert.ToString(lector["Segundo_apellido"]) ?? "";
            usuario.Email = Convert.ToString(lector["Email"]) ?? "";
            usuario.IdRol = Convert.ToInt32(lector["id_rol"]);
            usuario.Rol = Convert.ToString(lector["Rol"]) ?? "";

            if (incluirContrasena)
            {
                usuario.Contrasena = Convert.ToString(lector["Contrasena"]) ?? "";
            }

            return usuario;
        }

        public bool ExisteEmail(string email)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                using (MySqlCommand comando = new MySqlCommand("SELECT COUNT(*) FROM Usuario WHERE Email = @email", conexion))
                {
                    comando.Parameters.AddWithValue("@email", email);
                    return Convert.ToInt32(comando.ExecuteScalar()) > 0;
                }
            }
        }

        public void InsertarUsuario(Usuario usuario)
        {
            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = "INSERT INTO Usuario (Nombre, Primer_apellido, Segundo_apellido, Email, Contrasena, id_rol) " + "VALUES (@nombre, @primerApellido, @segundoApellido, @email, @contrasena, @idRol)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    comando.Parameters.AddWithValue("@primerApellido", usuario.PrimerApellido);
                    comando.Parameters.AddWithValue("@segundoApellido", usuario.SegundoApellido);
                    comando.Parameters.AddWithValue("@email", usuario.Email);
                    comando.Parameters.AddWithValue("@contrasena", usuario.Contrasena);
                    comando.Parameters.AddWithValue("@idRol", usuario.IdRol);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<CatalogoItem> ObtenerRoles()
        {
            List<CatalogoItem> roles = new List<CatalogoItem>();

            using (MySqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                using (MySqlCommand comando = new MySqlCommand("SELECT id_rol AS Id, Nombre FROM Rol ORDER BY id_rol", conexion))
                using (MySqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        CatalogoItem rol = new CatalogoItem();
                        rol.Id = Convert.ToInt32(lector["Id"]);
                        rol.Nombre = Convert.ToString(lector["Nombre"]) ?? "";
                        roles.Add(rol);
                    }
                }
            }
            return roles;
        }
    }
}