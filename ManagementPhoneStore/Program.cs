
using Entity;
using ManagementPhoneStore.util;
using Service;
using Service.impl;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI;

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


            Application.Run(new Log_InGUI());


            //IChiTietSanPhamService chiTietSanPham = new ChiTietSanPhamService();
           


            //Application.Run(new Log_InGUI());
            //IChiTietSanPhamService chiTietSanPham = new ChiTietSanPhamService();
            List<long> imeis = new List<long>();
            imeis.Add(107725056444798);
            imeis.Add(107725056444797);
            //chiTietSanPham.delete(107725056444797);
            //Console.WriteLine(chiTietSanPham.checkImeiExists(imeis));        
        }
    }
}
