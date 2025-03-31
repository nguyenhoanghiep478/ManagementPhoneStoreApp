using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
namespace ManagementPhoneStore.util
{
    public class MyBcrypt
    {
        public static string HashPassword(string password)
        {
            // Mã hóa mật khẩu với số lần băm là 12
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public static bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }
    }
}
