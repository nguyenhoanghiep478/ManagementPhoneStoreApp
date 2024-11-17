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
    public partial class ThuocTinhGUI : Form
    {
        public ThuocTinhGUI()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ThuocTinhDialog thuocTinhDialog = new ThuocTinhDialog("mausac");
            thuocTinhDialog.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThuocTinhDialog thuocTinhDialog = new ThuocTinhDialog("thuonghieu");
            thuocTinhDialog.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThuocTinhDialog thuocTinhDialog = new ThuocTinhDialog("xuatxu");
            thuocTinhDialog.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThuocTinhDialog thuocTinhDialog = new ThuocTinhDialog("hedieuhanh");
            thuocTinhDialog.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ThuocTinhDialog thuocTinhDialog = new ThuocTinhDialog("ram");
            thuocTinhDialog.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ThuocTinhDialog thuocTinhDialog = new ThuocTinhDialog("rom");
            thuocTinhDialog.ShowDialog();
        }
    }
}
