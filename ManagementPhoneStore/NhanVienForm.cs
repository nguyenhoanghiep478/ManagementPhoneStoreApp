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
    public partial class NhanVienForm : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void nv_prop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NhanVienForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None; // Loại bỏ viền form
            this.TopLevel = false;
        }
    }
}
