﻿
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
            SanPhamDAO sanPhamDAO = new SanPhamDAO();
            List<SanPham> sanPhams = sanPhamDAO.FindLikeName("Vivo");
            foreach(SanPham sanPham in sanPhams)
            {
                Console.WriteLine(sanPham);
            }
        }
    }
}
