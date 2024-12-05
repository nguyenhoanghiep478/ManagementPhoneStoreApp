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
        private List<string> actions;

        public ThuocTinhGUI()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.AliceBlue;

            this.FormBorderStyle = FormBorderStyle.None; // Loại bỏ viền form
            this.TopLevel = false;
        }
        public ThuocTinhGUI(List<string> actions)
        {
            this.actions=actions;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.AliceBlue;

            this.FormBorderStyle = FormBorderStyle.None; // Loại bỏ viền form
            this.TopLevel = false;
        }


        private void button6_Click(object sender, EventArgs e)
        {
            ThuocTinhDialog thuocTinhDialog = new ThuocTinhDialog("mausac",actions);
            thuocTinhDialog.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThuocTinhDialog thuocTinhDialog = new ThuocTinhDialog("thuonghieu",actions);
            thuocTinhDialog.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThuocTinhDialog thuocTinhDialog = new ThuocTinhDialog("xuatxu", actions);
            thuocTinhDialog.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThuocTinhDialog thuocTinhDialog = new ThuocTinhDialog("hedieuhanh", actions);
            thuocTinhDialog.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ThuocTinhDialog thuocTinhDialog = new ThuocTinhDialog("ram",actions);
            thuocTinhDialog.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ThuocTinhDialog thuocTinhDialog = new ThuocTinhDialog("rom", actions);
            thuocTinhDialog.ShowDialog();
        }
    }
}
