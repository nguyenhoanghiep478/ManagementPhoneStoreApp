using Entity;
using Service;
using Service.impl;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static GUI.PhieuNhapPanel;

namespace GUI
{
    public partial class ChiTietPhieuDialog : Form
    {
        private PhieuNhap phieunhap;
        private PhieuXuat phieuxuat;
        private PhienBanSanPhamService phienbanBus = PhienBanSanPhamService.Instance;
        private ChiTietSanPhamService ctspBus =  ChiTietSanPhamService.Instance;
        private PhieuNhapService phieunhapBus;
        private PhieuXuatService phieuxuatBus;
        private SanPhamService SanPham = SanPhamService.Instance;
        private DungLuongRamService dlramService = new DungLuongRamService ();
        private DungLuongRomService dlromService = new DungLuongRomService();
        private MauSacService mausacService = new MauSacService();
        private NhaChungCapService nccService= NhaChungCapService.Instance;
        private NhanVienService nvbus = NhanVienService.Instance    ;
        private List <ChiTietPhieu> chitietphieulist=new List<ChiTietPhieu> ();
        private Dictionary<int, List<ChiTietSanPham>> chiTietSanPham;
        public ChiTietPhieuDialog()
        {
            this.Visible   = false;
        }
        public ChiTietPhieuDialog(PhieuNhap pn)
        { 
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.Visible=true;
            phieunhap = pn;
            phieunhapBus = PhieuNhapService.Instance;
            chitietphieulist = phieunhapBus.GetChiTietPhieu_Type(pn.Maphieunhap);
            chiTietSanPham = ctspBus.getChiTietSanPhamByMaPN(pn.Maphieunhap);

            maphieu.Text = pn.Maphieunhap.ToString();
            time.Text = pn.Thoigian.ToString();            
            string tennv= nvbus.GetNameById(int.Parse((pn.Nguoitao)));
            nvnhap.Text = tennv;
            ncc.Text = nccService.GetTenNhaCungCap(pn.Manhacungcap);

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
