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
    public partial class ThongKeGUI : Form
    {
        public ThongKeGUI()
        {
            InitializeComponent();
           
        }

       

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tonKhoGUI_Load(object sender, EventArgs e)
        {
            this.tonKhoGUI.TopLevel = false;
            this.tonKhoGUI.FormBorderStyle = FormBorderStyle.None;
            this.tonKhoGUI.Dock = DockStyle.Fill;
        }

        private void thongKeDoanhThu_Load(object sender, EventArgs e)
        {
            this.thongKeDoanhThu.TopLevel = false;
            this.thongKeDoanhThu.FormBorderStyle = FormBorderStyle.None;
            this.thongKeDoanhThu.Dock = DockStyle.Fill;
        }
        private void ThongKe_Load(object sender, EventArgs e)
        {
            this.thongQuanGUI.TopLevel = false;
            this.thongQuanGUI.FormBorderStyle = FormBorderStyle.None;
            this.thongQuanGUI.Dock = DockStyle.Fill;
        }
    }
}
