
using DAO.DAO;
using DAO.DAO.impl;
using Entity;
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
            Application.Run(new Form1());
            IChiTietSanPham chiTietSanPham = new ChiTietSanPhamDAO();
            List<long> imeis = new List<long>();
            imeis.Add(107725056444798);
            imeis.Add(107725056444797);
            //chiTietSanPham.delete(107725056444797);
            Console.WriteLine(chiTietSanPham.checkImeiExists(imeis));


        }
    }
}
