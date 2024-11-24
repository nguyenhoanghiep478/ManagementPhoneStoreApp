using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.impl;
using Service;

namespace ManagementPhoneStore
{
    public partial class KhuVucKhoDialog : Form
    {

        private IKhuVucKhoService khuVucKhoService = KhuVucKhoService.Instance;
        public string TenKhuVuc { get => tenKhuVucKho.Text.Trim(); }
        public string GhiChu { get => ghichu.Text.Trim(); }

        public KhuVucKhoDialog()
        {
            InitializeComponent();
        }

        private void KhuVucKhoDialog_Load(object sender, EventArgs e)
        {

        }

        private void tenKhuVucKho_TextChanged(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tenKhuVucKho.Text))
            {
                MessageBox.Show("Tên khu vực không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (khuVucKhoService.CheckDup(tenKhuVucKho.Text))
            {
                MessageBox.Show("Tên khu vực không thể trùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                            "Bạn có chắc muốn hủy không?",
                            "Xác nhận",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
