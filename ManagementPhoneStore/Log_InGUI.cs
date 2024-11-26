using Entity;
using GUI;
using ManagementPhoneStore.util;
using Service.impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementPhoneStore
{
    public partial class Log_InGUI : Form
    {
        private TaiKhoanService taiKhoanService = TaiKhoanService.Instance;
        private NhanVienService nhanVienService = NhanVienService.Instance;
        private EmailHelper emailHelper = EmailHelper.Instace;
        private TaiKhoan updateTaiKhoan;
        private Timer timer;
        private int index;
        private int remainingSeconds;
        public Log_InGUI()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            CustomTextBox(textBox2,10);
            textBox1.Text = "admin";
            textBox2.Text = "chithanh";
        }
        private void CustomTextBox(TextBox textBox, int padding)
        {
            // Thiết lập Padding cho TextBox
            textBox.Padding = new Padding(padding);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            List<TaiKhoan> listTaikhoan = taiKhoanService.GetTaiKhoanAll();
            bool exist=false;
            foreach(TaiKhoan taiKhoan in listTaikhoan)
            {

                if (taiKhoan.Tendangnhap.Equals(textBox1.Text) && MyBcrypt.VerifyPassword(textBox2.Text, taiKhoan.Matkhau))
                {
                    this.Hide();
                    exist = true;
                    HomeGUI homeGUI = new HomeGUI(taiKhoan.Manv);
                    homeGUI.ShowDialog();
                    this.Close();
                }
            }
            if (exist == false)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            openForgotForm();
        }
       
        private void buttonBack_Click(object sender, EventArgs e)
        {
            label3.Text= "Tên đăng nhập";
            label4.Text = "mật khẩu";
            panel2.Visible = true;
            panel3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            button1.Visible = true;

            closeForgotForm();
            closeOtpForm();
            closeResetPasswordForm();
            textBox1.Text = "admin";
            textBox2.Text = "chithanh";
        }
        private void buttonRecover_Click(object sender, EventArgs e)
        {
           string username = this.textBoxForgotUsername.Text.Trim();
           this.updateTaiKhoan = taiKhoanService.Search(username, "Tên đăng nhập").First();
            if(updateTaiKhoan == null)
            {
                MessageBox.Show("Tên đăng nhập không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            sendResetPassRequest();

            MessageBox.Show("Otp đã gửi đến email của bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            label3.Text = "OTP";
            openOtpForm();
           
           

        }

        private void closeForgotForm()
        {
            panelForgotUsername.Visible = false;
            panelForgotButtons.Visible = false;
        }

        private void openForgotForm()
        {
            panel2.Visible = false;
            panel3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            button1.Visible = false;


            panelForgotUsername.Visible = true;
            panelForgotButtons.Visible = true;
        }
        private void openOtpForm()
        {
            closeForgotForm();
            panelOTPInput.Visible = true;
            panelOTPButtons.Visible = true;
            panelOTPCountDown.Visible = true;
            this.labelCountdown.Visible = true;

            StartOTPCountdown(5 * 60);
        }

        private void openResetPasswordForm()
        {
            closeOtpForm();
           this.panelResetPasswordButtons.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            label4.Visible = true;
            this.textBox1.PasswordChar = '•'; 
            this.textBox1.UseSystemPasswordChar = true;
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
            this.label3.Text = "mật khẩu mới";
            this.label4.Text = "Xác nhận mật khẩu mới";
        }

        private void closeResetPasswordForm()
        {
            this.panelResetPasswordButtons.Visible = false;
            this.textBox1.UseSystemPasswordChar = false;
            this.textBox1.PasswordChar = '\0';
        }

        private void closeOtpForm()
        {
            panelOTPInput.Visible = false;
            panelOTPButtons.Visible = false;
            panelOTPCountDown.Visible = false;
            this.labelCountdown.Visible = false;
        }

        private void sendResetPassRequest()
        {
            int index = nhanVienService.GetIndexById(updateTaiKhoan.Manv);
            NhanVien nv = nhanVienService.GetByIndex(index);

            Random random = new Random();
            string otp = random.Next(100000, 1000000).ToString();

            emailHelper.SendEmail(nv, otp);

            updateTaiKhoan.Otp = otp;


            taiKhoanService.UpdateAcc(taiKhoanService.GetTaiKhoanByMaNV(updateTaiKhoan.Manv), updateTaiKhoan);

        }
        private void ButtonOTPConfirm_Click(object sender, EventArgs e)
        {
            handleValidOtp();
        }
        private void handleValidOtp()
        {
            string otp = textBoxOTP.Text.Trim();

            if (!updateTaiKhoan.Otp.Equals(otp))
            {
                MessageBox.Show("Otp không hợp lệ , hãy kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            timer.Stop();

            openResetPasswordForm();


        }
        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Blue; 
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black; 
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StartOTPCountdown(int seconds)
        {
            remainingSeconds = seconds;

            timer = new Timer
            {
                Interval = 1000 
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (remainingSeconds > 0)
            {
                remainingSeconds--;
                TimeSpan time = TimeSpan.FromSeconds(remainingSeconds);
                labelCountdown.Text = $"Thời gian còn lại: {time.Minutes:D2}:{time.Seconds:D2}";
            }
            else
            {
                timer.Stop();
                sendResetPassRequest();
                MessageBox.Show("Otp đã gửi lại đến email của bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBoxOTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBoxOTP.Text.Length >= 6 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                handleValidOtp();

            }
            else if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void handleResetPassword(object sender, EventArgs e)
        {
            String password = this.textBox1.Text.Trim();
            string confirmPassword = this.textBox2.Text.Trim();

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!password.Equals(confirmPassword)) {
             MessageBox.Show("Mật khẩu không trùng khớp , vui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string hashedPassword = MyBcrypt.HashPassword(password);
            updateTaiKhoan.Matkhau = hashedPassword;

            this.taiKhoanService.UpdateAcc(index, updateTaiKhoan);

            this.buttonBack_Click(sender, e);
            MessageBox.Show("Cập nhật mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
