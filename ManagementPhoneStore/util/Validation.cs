using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ManagementPhoneStore.util
{
    public class Validation
    {
        public static bool IsEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        // Kiểm tra xem chuỗi có phải là địa chỉ email hợp lệ hay không
        public static bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            string emailRegex = @"^[a-zA-Z0-9_+&*-]+(?:\.[a-zA-Z0-9_+&*-]+)*@(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,7}$";
            return Regex.IsMatch(email, emailRegex);
        }

        // Kiểm tra xem chuỗi có phải là số hay không
        public static bool IsNumber(string num)
        {
            if (string.IsNullOrEmpty(num))
            {
                return false;
            }

            if (long.TryParse(num, out long k))
            {
                return k >= 0; // Kiểm tra xem số có âm hay không
            }

            return false; // Không thể chuyển đổi thành số
        }
    }
}
