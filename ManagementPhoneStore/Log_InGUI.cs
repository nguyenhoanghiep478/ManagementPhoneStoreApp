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
            TaiKhoanService taiKhoanService= new TaiKhoanService();
            List<TaiKhoan> listTaikhoan = taiKhoanService.GetTaiKhoanAll();
            foreach(TaiKhoan taiKhoan in listTaikhoan)
            {
                if (taiKhoan.Tendangnhap.Equals(textBox1.Text) && MyBcrypt.VerifyPassword(textBox2.Text, taiKhoan.Matkhau))
                {
                    this.Hide();
                    HomeGUI homeGUI = new HomeGUI(taiKhoan.Manv);
                    homeGUI.ShowDialog();
                    this.Close();
                }
            }
            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
