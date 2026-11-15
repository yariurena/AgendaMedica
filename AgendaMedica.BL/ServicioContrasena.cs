using System;
using System.Security.Cryptography;

namespace AgendaMedica.BL
{
    public static class ServicioContrasena
    {
        private const int TamanoSal = 16;
        private const int TamanoHash = 32;
        private const int Iteraciones = 100000;

        public static string Crear(string contrasena)
        {
            byte[] sal = RandomNumberGenerator.GetBytes(TamanoSal);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(contrasena, sal, Iteraciones, HashAlgorithmName.SHA256, TamanoHash);

            return "PBKDF2$" + Iteraciones + "$" + Convert.ToBase64String(sal) + "$" + Convert.ToBase64String(hash);
        }

        public static bool Verificar(string contrasena, string guardada)
        {
            string[] partes = guardada.Split('$');

            if (partes.Length != 4 || partes[0] != "PBKDF2")
            {
                return false;
            }

            if (!int.TryParse(partes[1], out int iteraciones))
            {
                return false;
            }

            try
            {
                byte[] sal = Convert.FromBase64String(partes[2]);
                byte[] esperado = Convert.FromBase64String(partes[3]);
                byte[] calculado = Rfc2898DeriveBytes.Pbkdf2(contrasena, sal, iteraciones, HashAlgorithmName.SHA256, esperado.Length);

                return CryptographicOperations.FixedTimeEquals(calculado, esperado);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}