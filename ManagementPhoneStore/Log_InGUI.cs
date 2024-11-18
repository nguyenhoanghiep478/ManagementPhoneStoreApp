using GUI;
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
            textBox1.Text = "admin";
            textBox2.Text = "123456";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("admin") && textBox2.Text.Equals("123456"))
            {
                this.Hide();
                SanPhamGUI sanPhamGUI = new SanPhamGUI();
                sanPhamGUI.ShowDialog();

                //ThuocTinhGUI thuocTinhGUI = new ThuocTinhGUI();
                //thuocTinhGUI.ShowDialog();

                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
