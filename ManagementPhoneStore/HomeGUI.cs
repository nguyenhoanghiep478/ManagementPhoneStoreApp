using ManagementPhoneStore;
using Service.impl;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class HomeGUI : Form
    {
        private int manv;
        private TaiKhoanService taiKhoanService=new TaiKhoanService();
        private NhanVienService NhanVienService = new NhanVienService();
        private NhomQuyenService NhomQuyenService = new NhomQuyenService();
        public HomeGUI(int manv)
        {
            this.manv = manv;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            label1.Text=NhanVienService.GetNameById(manv);
            label2.Text=NhomQuyenService.getNameByMA(manv);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SanPhamGUI sanPhamGUI = new SanPhamGUI();
            sanPhamGUI.TopLevel = false;
            sanPhamGUI.Dock = DockStyle.Fill;

            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(sanPhamGUI);
            sanPhamGUI.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(panel3);
            panelContainer.Controls.Add(panel4);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            HomeGUI homeForm = new HomeGUI(manv);
            homeForm.Show();
        }

        private void HomeGUI_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.DarkGray;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            SanPhamGUI spform = new SanPhamGUI();
            spform.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThuocTinhGUI ttform = new ThuocTinhGUI();
            ttform.TopLevel = false;
            ttform.Dock = DockStyle.Fill;

            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(ttform);
            ttform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //AreaGUI kvform = new AreaGUI();
            //kvform.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //PhieunhapGUI phieuNhapform = new PhieunhapGUI();
            //phieuNhapform.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //PhieuxuatGUI phieuXuatform = new PhieuxuatGUI();
            //phieuXuatform.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            KhachHangForm khachHangform = new KhachHangForm();
            khachHangform.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NhaCungCapForm nhaCungcap = new NhaCungCapForm();
            nhaCungcap.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ListNhanVien nhanVienform = new ListNhanVien();
            nhanVienform.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TaiKhoanForm taiKhoanform = new TaiKhoanForm();
            taiKhoanform.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //ThongKeTonKho thongkeForm = new ThongKeTonKho();
            //thongkeForm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //PhanquyenGUI phanquyenForm = new PhanquyenGUI();
            //phanquyenForm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Log_InGUI loginForm = new Log_InGUI();
            this.Hide();
            loginForm.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
