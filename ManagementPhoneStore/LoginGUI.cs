
using Entity;
using Service.impl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementPhoneStore
{
    public partial class LoginGUI : Form
    {
        private Panel pnlMain;
        private Label lblTitle, lblForgotPassword;
        private TextBox txtUsername, txtPassword;
        private Button btnLogin;

        public LoginGUI()
        {
            InitializeComponent();
            SetPlaceholder(txtUsername, "Tên đăng nhập");
            SetPlaceholder(txtPassword, "Mật khẩu", true);
        }

        private void InitializeComponent()
        {
            // Form settings
            this.Text = "Đăng nhập";
            this.Size = new Size(1000, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Main Panel
            pnlMain = new Panel
            {
                Size = new Size(500, 500),
                BackColor = Color.White,
                Location = new Point(500, 0)
            };
            this.Controls.Add(pnlMain);

            // Title Label
            lblTitle = new Label
            {
                Text = "ĐĂNG NHẬP VÀO HỆ THỐNG",
                Font = new Font("Roboto", 12, FontStyle.Bold),
                Location = new Point(50, 20),
                AutoSize = true
            };
            pnlMain.Controls.Add(lblTitle);

            // Username TextBox
            txtUsername = new TextBox
            {
                Size = new Size(400, 30),
                Location = new Point(50, 60),
                ForeColor = Color.Gray
            };
            pnlMain.Controls.Add(txtUsername);

            // Password TextBox
            txtPassword = new TextBox
            {
                Size = new Size(400, 30),
                Location = new Point(50, 100),
                ForeColor = Color.Gray,
                UseSystemPasswordChar = false // Initially show placeholder
            };
            pnlMain.Controls.Add(txtPassword);

            // Login Button
            btnLogin = new Button
            {
                Text = "ĐĂNG NHẬP",
                Size = new Size(400, 40),
                Location = new Point(50, 150),
                BackColor = Color.Black,
                ForeColor = Color.White
            };
            btnLogin.Click += BtnLogin_Click;
            btnLogin.MouseEnter += BtnLogin_MouseEnter;
            btnLogin.MouseLeave += BtnLogin_MouseLeave;
            pnlMain.Controls.Add(btnLogin);

            // Forgot Password Label
            lblForgotPassword = new Label
            {
                Text = "Quên mật khẩu",
                Font = new Font("Roboto", 10, FontStyle.Italic),
                Location = new Point(50, 200),
                AutoSize = true,
                ForeColor = Color.Blue
            };
            lblForgotPassword.Click += LblForgotPassword_Click;
            pnlMain.Controls.Add(lblForgotPassword);
        }

        private void SetPlaceholder(TextBox textBox, string placeholder, bool isPassword = false)
        {
            textBox.Text = placeholder;
            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                    if (isPassword)
                    {
                        textBox.UseSystemPasswordChar = true;
                    }
                }
            };

            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.UseSystemPasswordChar = false; // Disable to show placeholder
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }

        private void BtnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.Gray;
        }

        private void BtnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.Black;
        }

        private void LblForgotPassword_Click(object sender, EventArgs e)
        {
            // Show forgot password dialog or message
            MessageBox.Show("Quên mật khẩu được nhấn!");
        }

        private void CheckLogin()
        {
            string usernameCheck = txtUsername.Text;
            string passwordCheck = txtPassword.Text;

            // Check if the username or password is still in placeholder state
            if (usernameCheck == "Tên đăng nhập" || passwordCheck == "Mật khẩu" || string.IsNullOrEmpty(usernameCheck) || string.IsNullOrEmpty(passwordCheck))
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Console.WriteLine(usernameCheck);
            Console.WriteLine(passwordCheck);
            // if (tk == null) {...}
        }
    }
}
