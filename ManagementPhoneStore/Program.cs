
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
      
            Application.Run(new KhachHangForm());

            //IChiTietSanPhamService chiTietSanPham = new ChiTietSanPhamService();
           
            //chiTietSanPham.delete(107725056444797);
            //Console.WriteLine(chiTietSanPham.checkImeiExists(imeis));


        }
    }
}
