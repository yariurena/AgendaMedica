using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using AgendaMedica.DAL;
using AgendaMedica.Modelos;

namespace AgendaMedica.BL
{
    public class ServicioUsuario
    {
        public const string CorreoAdministradorInicial = "admin@agendamedica.com";
        public const string ContrasenaAdministradorInicial = "Admin2026!";

        private readonly UsuarioDAL datos = new UsuarioDAL();

        public bool AsegurarAdministradorInicial()
        {
            if (datos.ContarUsuarios() > 0)
            {
                return false;
            }

            CatalogoItem? rolAdmin = datos.ObtenerRoles().FirstOrDefault(r => r.Nombre == "Administrador");

            if (rolAdmin == null)
            {
                throw new InvalidOperationException("No existe el rol 'Administrador' en la base de datos.");
            }

            Usuario admin = new Usuario
            {
                Nombre = "Administrador",
                PrimerApellido = "del",
                SegundoApellido = "Sistema",
                Email = CorreoAdministradorInicial,
                Contrasena = ServicioContrasena.Crear(ContrasenaAdministradorInicial),
                IdRol = rolAdmin.Id
            };

            datos.InsertarUsuario(admin);
            return true;
        }

        public Usuario IniciarSesion(string email, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(contrasena))
            {
                throw new ArgumentException("Debe ingresar el correo y la contraseña.");
            }

            Usuario? usuario = datos.ObtenerPorEmail(email.Trim());

            if (usuario == null || !ServicioContrasena.Verificar(contrasena, usuario.Contrasena))
            {
                throw new InvalidOperationException("Correo o contraseña incorrectos.");
            }

            SesionActual.Iniciar(usuario);
            return usuario;
        }

        public void CerrarSesion()
        {
            SesionActual.Cerrar();
        }

        public List<CatalogoItem> ObtenerRoles()
        {
            return datos.ObtenerRoles();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            ExigirAdministrador();
            return datos.ObtenerUsuarios();
        }

        public void RegistrarUsuario(Usuario usuario, string contrasena, string confirmacion)
        {
            ExigirAdministrador();

            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            usuario.Nombre = usuario.Nombre?.Trim() ?? "";
            usuario.PrimerApellido = usuario.PrimerApellido?.Trim() ?? "";
            usuario.SegundoApellido = usuario.SegundoApellido?.Trim() ?? "";
            usuario.Email = usuario.Email?.Trim() ?? "";

            if (usuario.Nombre.Length == 0)
            {
                throw new ArgumentException("El nombre es obligatorio.");
            }

            if (usuario.PrimerApellido.Length == 0)
            {
                throw new ArgumentException("El primer apellido es obligatorio.");
            }

            if (usuario.SegundoApellido.Length == 0)
            {
                throw new ArgumentException("El segundo apellido es obligatorio.");
            }

            if (usuario.Nombre.Length > 100 || usuario.PrimerApellido.Length > 100 || usuario.SegundoApellido.Length > 100)
            {
                throw new ArgumentException("El nombre y los apellidos no pueden superar los 100 caracteres.");
            }

            if (!EsCorreoValido(usuario.Email))
            {
                throw new ArgumentException("El correo electrónico no tiene un formato válido.");
            }

            ValidarContrasena(contrasena);

            if (contrasena != confirmacion)
            {
                throw new ArgumentException("La contraseña y su confirmación no coinciden.");
            }

            if (!datos.ObtenerRoles().Any(r => r.Id == usuario.IdRol))
            {
                throw new ArgumentException("Debe seleccionar un rol válido.");
            }

            if (datos.ExisteEmail(usuario.Email))
            {
                throw new InvalidOperationException("Ya existe un usuario con ese correo electrónico.");
            }

            usuario.Contrasena = ServicioContrasena.Crear(contrasena);

            datos.InsertarUsuario(usuario);
        }

        private void ExigirAdministrador()
        {
            if (!SesionActual.EsAdministrador)
            {
                throw new UnauthorizedAccessException("Solo un administrador puede realizar esta acción.");
            }
        }

        private static void ValidarContrasena(string contrasena)
        {
            if (string.IsNullOrEmpty(contrasena) || contrasena.Length < 8)
            {
                throw new ArgumentException("La contraseña debe tener al menos 8 caracteres.");
            }

            if (!contrasena.Any(char.IsLetter) || !contrasena.Any(char.IsDigit))
            {
                throw new ArgumentException("La contraseña debe incluir al menos una letra y un número.");
            }
        }

        private static bool EsCorreoValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length > 150)
            {
                return false;
            }

            try
            {
                MailAddress direccion = new MailAddress(email);
                return direccion.Address == email;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}