using BCrypt.Net;
using System;
using System.ComponentModel;

public class PasswordHelper
{
    public static Lazy<PasswordHelper> instance = new Lazy<PasswordHelper>(() => new PasswordHelper());
    public static PasswordHelper Instance => instance.Value;
    public static string GenerateSalt(int workFactor = 10)
    {
        // Generates a salt with the specified work factor (default is 10)
        return BCrypt.Net.BCrypt.GenerateSalt(workFactor);
    }

    public static string HashPassword(string password, int workFactor = 10)
    {
        // Generates salt and hashes the password
        string salt = GenerateSalt(workFactor);
        return BCrypt.Net.BCrypt.HashPassword(password, salt);
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Verify the password against the hash
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
