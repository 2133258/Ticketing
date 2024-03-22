using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorApp.Helpers
{
    //Code copier d'un ancient projet de la session passé (Gestion de projet en Dev d'application expert) Auteur : William, Xavier et Nataniel
    public static class CryptographyHelper
    {
        /// <summary>
        /// hash le mot de passe entrée en paramètre
        /// </summary>
        /// <param name="passwordToHash">Mot de passe a Hasher</param>
        /// <returns>le mot de passe hasher</returns>
        public static string HashPassword(string passwordToHash)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            var pdkdf2 = new Rfc2898DeriveBytes(passwordToHash, salt, 4855);
            byte[] hash = pdkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// Compare un mot string hasher et un string en texte clair et détermine si il correspondes
        /// </summary>
        /// <param name="password">Mot de passe a verifier</param>
        /// <param name="hashedPassword">Mot de passe Hasher</param>
        /// <returns></returns>
        public static bool ValidateHashedPassword(string password, string hashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 4855);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
