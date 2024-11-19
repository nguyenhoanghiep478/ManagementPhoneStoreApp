
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
            this.SuspendLayout();
            // 
            // LoginGUI
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "LoginGUI";
            this.Load += new System.EventHandler(this.LoginGUI_Load);
            this.ResumeLayout(false);

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

        private void LoginGUI_Load(object sender, EventArgs e)
        {

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
