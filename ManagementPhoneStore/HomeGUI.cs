using Entity;
using ManagementPhoneStore;
using Service.impl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class HomeGUI : Form
    {
        private int manv;
        private TaiKhoanService taiKhoanService=TaiKhoanService.Instance;
        private NhanVienService NhanVienService = NhanVienService.Instance;
        private NhomQuyenService NhomQuyenService = NhomQuyenService.Instace;
        private NhomQuyen nhomQuyens;
        private List<ChiTietQuyen> authors;
        public HomeGUI(int manv)
        {
            this.manv = manv;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            label1.Text=NhanVienService.GetNameById(manv);
            label2.Text=NhomQuyenService.getNameByMA(manv);
            panelContainer.AutoSize = false;
            this.nhomQuyens = taiKhoanService.GetNhomQuyen(manv);
            this.authors = NhomQuyenService.GetChiTietQuyen(nhomQuyens.Tennhomquyen);
            handleAuthor();
        }

        private void handleAuthor()
        {
            if (!authors.Any(g => g.MaChucNang.Equals("sanpham")))
            {
                this.panel2.Controls.Remove(button2);
            }

            if (!authors.Any(g => g.MaChucNang.Equals("khachhang")))
            {
                this.panel2.Controls.Remove(button7);
            }

            if (!authors.Any(g => g.MaChucNang.Equals("khuvuckho")))
            {
                this.panel2.Controls.Remove(button4);
            }
            if (!authors.Any(g => g.MaChucNang.Equals("nhacungcap")))
            {
                this.panel2.Controls.Remove(button8);

            }
            if (!authors.Any(g => g.MaChucNang.Equals("nhaphang")))
            {
                this.panel2.Controls.Remove(button5);
            }
            if (!authors.Any(g => g.MaChucNang.Equals("nhomquyen")))
            {
                this.panel2.Controls.Remove(button12);
            }
            if (!authors.Any(g => g.MaChucNang.Equals("taikhoan")))
            {
                this.panel2.Controls.Remove(button10);
            }
            if (!authors.Any(g => g.MaChucNang.Equals("thongke")))
            {
                this.panel2.Controls.Remove(button11);
            }
            if (!authors.Any(g => g.MaChucNang.Equals("thuoctinh")))
            {
                this.panel2.Controls.Remove(button3);
            }
            if (!authors.Any(g => g.MaChucNang.Equals("nhanvien")))
            {
                this.panel2.Controls.Remove(button9);
            }
            if (!authors.Any(g => g.MaChucNang.Equals("xuathang")))
            {
                this.panel2.Controls.Remove(button6);
            }
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
            //HomeGUI homeForm = new HomeGUI(manv);
            //homeForm.Show();
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
            KhuVucKhoForm kvk = new KhuVucKhoForm();
            kvk.TopLevel = false;
            kvk.Dock = DockStyle.Fill;

            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(kvk);

            kvk.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PhieuNhapPanel phieuNhapPanel = new PhieuNhapPanel(manv);

            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(phieuNhapPanel);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //PhieuxuatGUI phieuXuatform = new PhieuxuatGUI();
            //phieuXuatform.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            KhachHangForm khachHangform = new KhachHangForm();
            khachHangform.TopLevel = false;
            khachHangform.Dock = DockStyle.Fill;

            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(khachHangform);
            khachHangform.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NhaCungCapForm nhaCungcap = new NhaCungCapForm();
            nhaCungcap.TopLevel = false;
            nhaCungcap.Dock = DockStyle.Fill;

            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(nhaCungcap);
            nhaCungcap.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            NhanVienForm nhanVienform = new NhanVienForm();
            nhanVienform.TopLevel = false;
            nhanVienform.Dock = DockStyle.Fill;

            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(nhanVienform);
            nhanVienform.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TaiKhoanForm taiKhoanform = new TaiKhoanForm();
            taiKhoanform.TopLevel = false;
            taiKhoanform.Dock = DockStyle.Fill;

            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(taiKhoanform);
            taiKhoanform.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ThongKeGUI thongkeForm = new ThongKeGUI();
            thongkeForm.Dock = DockStyle.Fill;
           
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(thongkeForm);
            thongkeForm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            PhanQuyenGUI phanquyenForm = new PhanQuyenGUI();
            phanquyenForm.TopLevel = false;
            phanquyenForm.Dock = DockStyle.Fill;

            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(phanquyenForm);
            phanquyenForm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Log_InGUI loginForm = new Log_InGUI();
            this.Hide();
            loginForm.ShowDialog();
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
