using Entity;
using Service;
using Service.impl;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static GUI.PhieuNhapPanel;

namespace GUI
{
    public partial class ChiTietPhieuXuatDialog : Form
    {

        private PhieuXuat phieuxuat;
        private PhienBanSanPhamService phienbanBus = PhienBanSanPhamService.Instance;
        private ChiTietSanPhamService ctspBus = ChiTietSanPhamService.Instance;

        private PhieuXuatService phieuxuatBus = PhieuXuatService.Instance;
        private KhachHangService khachHangService = new KhachHangService();
        private SanPhamService SanPham = SanPhamService.Instance;
        private DungLuongRamService dlramService = new DungLuongRamService();
        private DungLuongRomService dlromService = new DungLuongRomService();
        private MauSacService mausacService = new MauSacService();
        private NhaChungCapService nccService = NhaChungCapService.Instance;
        private NhanVienService nvbus = NhanVienService.Instance;
        private List<ChiTietPhieu> chitietphieulist = new List<ChiTietPhieu>();
        private Dictionary<int, List<ChiTietSanPham>> chiTietSanPham;
        public ChiTietPhieuXuatDialog()
        {
            this.Visible = false;
        }
        public ChiTietPhieuXuatDialog(PhieuXuat px)
        {
            InitializeComponent();
            this.Visible = true;
            phieuxuat = px;
            chitietphieulist = phieuxuatBus.GetChiTietPhieu_Type((int)px.Maphieuxuat);
            chiTietSanPham = ctspBus.getChiTietSanPhamByMaPX((int)px.Maphieuxuat);

            maphieu.Text = px.Maphieuxuat.ToString();
            time.Text = px.Thoigian.ToString();
            string tennv = nvbus.GetNameById((int)px.Nguoitaophieuxuat);
            nvnhap.Text = tennv;
            ncc.Text = khachHangService.getTenKhachHang((int)px.Makh);

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            LoadDataTableChiTietPhieu(chitietphieulist);
            dataGridView1.CellClick += TableChitiet_CellClick;

        }
        public void LoadDataTableChiTietPhieu(List<ChiTietPhieu> chiTietPhieuList)
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < chiTietPhieuList.Count; i++)
            {
                var chiTietPhieu = chiTietPhieuList[i];

                var phienBanSanPham = phienbanBus.GetByMaPhienBan(chiTietPhieu.MaPhienBanSanPham);
                var sanPham = SanPham.GetSp(chiTietPhieu.MaPhienBanSanPham);
                var ram = dlramService.getKichThuocById((int)phienBanSanPham.Ram);
                var rom = dlromService.getKichThuocById((int)phienBanSanPham.Rom);
                var mauSac = mausacService.GetTenMau(phienBanSanPham.MauSac);
                dataGridView1.Rows.Add(
                      i + 1, // Row number
                      phienBanSanPham.MaSanPham, // Product ID
                      sanPham.Tensp, // Product name
                      $"{ram}GB", // RAM size
                      $"{rom}GB", // ROM size
                      mauSac, // Color name
                      Formater.FormatVND(chiTietPhieu.Dongia), // Formatted price
                      chiTietPhieu.SoLuong // Quantity

                  );
            }
        }

        public void LoadDataTableImei(List<ChiTietSanPham> dssp)
        {
            dataGridView2.Rows.Clear();

            for (int i = 0; i < dssp.Count; i++)
            {
                dataGridView2.Rows.Add(i + 1, dssp[i].MaImei);
            }
        }
        private void TableChitiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;

            if (index != -1)
            {
                LoadDataTableImei(chiTietSanPham[chitietphieulist[index].MaPhienBanSanPham]);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ChiTietPhieuDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
