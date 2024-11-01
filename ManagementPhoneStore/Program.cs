
using Entity;
using Service;
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
            Application.Run(new LoginGUI());
            //IChiTietSanPhamService chiTietSanPham = new ChiTietSanPhamService();
            INhaCungCapService nhaCungCapService = new NhaChungCapService();
            NhaCungCap ncc = new NhaCungCap(8, "Công ty Oppo Việt Nam 2222", "27 Đ. Nguyễn Trung Trực, Phường Bến Thành, Quận 1, Thành phố Hồ Chí Minh", "oppovietnam@oppo.vn", "0456345234",1);
            nhaCungCapService.Add(ncc);
            //chiTietSanPham.delete(107725056444797);
            //Console.WriteLine(chiTietSanPham.checkImeiExists(imeis));


        }
    }
}
