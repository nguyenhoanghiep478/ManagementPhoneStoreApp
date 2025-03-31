using Entity;
using ManagementPhoneStore.util;
using Service;
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
    public partial class LoginFormcs : Form
    {
        private ITaiKhoanService taiKhoanService = TaiKhoanService.Instance;
        public LoginFormcs()
        {
            InitializeComponent();
        }

        private void LoginFormcs_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            List<TaiKhoan> taikhoan = taiKhoanService.Search(txtTaiKhoan.Text, "Tên đăng nhập");
            if(taikhoan.Count <1)
            {
                throw new Exception("Login Failed");
            }
            TaiKhoan currentLogin = taikhoan[0];
            Console.WriteLine(txtMatKhau.Text);
            if (MyBcrypt.VerifyPassword(txtMatKhau.Text, currentLogin.Matkhau))
            {
              if(currentLogin.Manhomquyen != null)
                {
                    NhomQuyen nhomQuyen = taiKhoanService.GetNhomQuyen((int)currentLogin.Manhomquyen);
                    
                }
                
            }
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtTaiKhoan = (TextBox)sender;

            Console.WriteLine(txtTaiKhoan.Text);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            txtMatKhau = (TextBox)sender;
        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
