using System;
using System.Security.Cryptography;

public static class PasswordHasher
{
    //public static string HashPassword(string password)
    //{

    //    byte[] salt = new byte[16];
    //    using (var rng = new RNGCryptoServiceProvider())
    //    {
    //        rng.GetBytes(salt);
    //    }


    //    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());

    //    return hashedPassword;
    //}

    //public static bool VerifyPassword(string password, string hashedPassword)
    //{

    //    return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    //}
}
