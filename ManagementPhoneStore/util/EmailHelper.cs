using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementPhoneStore.util
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using DocumentFormat.OpenXml.Wordprocessing;
    using dotenv.net;
    using Entity;

    public class EmailHelper
    {
        private static Lazy<EmailHelper> instace = new Lazy<EmailHelper>(() => new EmailHelper());
        public static EmailHelper Instace => instace.Value;
        public async Task SendEmail( NhanVien nhanvien,string otp)
        {
            try
            {
                String subject = "Lấy lại mật khẩu";
              
                string currentDirectory = Directory.GetCurrentDirectory();
                Console.WriteLine($"Current Directory: {currentDirectory}");
                DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { "D:\\ManagementPhoneStoreApp\\.env" }));
                string fromEmail = Environment.GetEnvironmentVariable("EMAIL");
                string password = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
                string body = getBody(otp.ToString(),nhanvien);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(nhanvien.Email);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true; 

                // Cấu hình SMTP client
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587) // SMTP Gmail
                {
                    Credentials = new NetworkCredential(fromEmail, password),
                    EnableSsl = true // Bật SSL để bảo mật
                };

                // Gửi email
                smtpClient.Send(mail);
                Console.WriteLine("Email đã gửi thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Có lỗi xảy ra: {ex.Message}");
            }
        }

        private string getBody(string otp,NhanVien nhanvien)
        {
            string body = $@"
            <!DOCTYPE html>
            <html lang='en'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>OTP Reset Password</title>
                <style>
                    body {{ font-family: Arial, sans-serif; margin: 0; padding: 0; background-color: #f4f4f9; color: #333333; }}
                    .container {{ width: 100%; max-width: 600px; margin: 0 auto; padding: 20px; background-color: #ffffff; border-radius: 8px; box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1); }}
                    .header {{ text-align: center; padding: 20px; background-color: #4CAF50; color: white; border-radius: 8px 8px 0 0; }}
                    .header h1 {{ margin: 0; font-size: 24px; }}
                    .content {{ padding: 20px; line-height: 1.6; }}
                    .otp {{ display: inline-block; background-color: #f4f4f9; color: #4CAF50; font-size: 24px; font-weight: bold; padding: 10px 20px; border: 1px solid #4CAF50; border-radius: 8px; margin: 20px 0; text-align: center; }}
                    .footer {{ text-align: center; margin-top: 20px; font-size: 14px; color: #777777; }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <div class='header'>
                        <h1>Cập nhật mật khẩu</h1>
                    </div>
                    <div class='content'>
                        <p>Dear {nhanvien.Hoten},</p>
                        <p>Bạn đã yêu cầu cập nhật mật khẩu. Sử dụng otp bên dưới để cập nhật mật khẩu:</p>
                        <div class='otp'>{otp}</div>
                        <p>OTP này chỉ hợp lệ trong <strong>5 phút</strong>. Đừng chia sẻ mã này với ai.</p>
                        <p>Nếu bạn không yêu cầu, hãy bỏ qua nó hoặc liên hệ với account.support@gmail.com để được hỗ trợ.</p>
                        <p>Thân ái,</p>
                        <p><strong>Cửa hàng điện thoại SGU</strong></p>
                    </div>
                    <div class='footer'>
                        <p>© 2024 Cửa hàng điện thoại SGU. All rights reserved.</p>
                    </div>
                </div>
            </body>
            </html>";
            return body;
        }
    }
}
