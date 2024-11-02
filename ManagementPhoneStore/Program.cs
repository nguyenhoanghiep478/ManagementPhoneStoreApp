
using Entity;
using Service;
using Service.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementPhoneStore
{

    internal static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           //PhieuXuat px=new PhieuXuat();
           //SanPham sp=new SanPham();
           // sp.Xuatxu = 1;
           // sp.Khuvuckho = 1;
           // sp.Masp = 16;
           // sp.Tensp = "test";
           // sp.Hinhanh = "286samsung-galaxy-s20-fan-edition-xanh-la-thumbnew-600x600.jpeg";
           // sp.Chipxuly = "MediaTek Helio G85";
           // sp.Dungluongpin = 5000;
           // sp.Kichthuocman = 6.67;
           // sp.Hedieuhanh = 1;
           // sp.Phienbanhdh = 12;
           // sp.Camerasau = "Chính 50 MP & Phụ 8 MP, 2 MP";
           // sp.Cameratruoc = "13 MB";
           // sp.Thoigianbaohanh = 24;
           // sp.Thuonghieu = 2;
           // sp.Soluongton = 10;
           // sp.Trangthai = true;
           // NhaChungCapService.Instance.test(sp);
            Application.Run(new KhachHangForm());

            //IChiTietSanPhamService chiTietSanPham = new ChiTietSanPhamService();
            INhaCungCapService nhaCungCapService = new NhaChungCapService();
            NhaCungCap ncc = new NhaCungCap(8, "Công ty Oppo Việt Nam 2222", "27 Đ. Nguyễn Trung Trực, Phường Bến Thành, Quận 1, Thành phố Hồ Chí Minh", "oppovietnam@oppo.vn", "0456345234",1);
            nhaCungCapService.Add(ncc);
            //chiTietSanPham.delete(107725056444797);
            //Console.WriteLine(chiTietSanPham.checkImeiExists(imeis));


        }
    }
}
