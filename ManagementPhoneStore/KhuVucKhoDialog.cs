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
using Entity;

namespace ManagementPhoneStore
{
    public partial class KhuVucKhoDialog : Form
    {

        private IKhuVucKhoService khuVucKhoService = KhuVucKhoService.Instance;
        public string TenKhuVuc { get => tenKhuVucKho.Text.Trim(); }
        private KhuVucKho kvk;
        public string GhiChu { get => ghichu.Text.Trim(); }

        public KhuVucKhoDialog()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public KhuVucKhoDialog(KhuVucKho khuVucKho)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.kvk = khuVucKho;
            this.tenKhuVucKho.Text = kvk.Tenkhuvuc;
            this.ghichu.Text = kvk.Ghichu;
            this.label1.Text = "Sửa khu vực kho";
            this.add.Text = "Sửa khu vực kho";
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
