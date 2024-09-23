using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PhienBanSanPham
    {
        public int MaPhienBanSanPham {  get; set; }
        public int MaSanPham { get; set; }
        public int rom {  get; set; }
        public int ram { get; set; }

        public int MauSac {  get; set; }
        
        public long GiaNhap { get; set; }  
        public long GiaXuat { get; set; }

        public int SoLuongTon { get; set; }

        public int TrangThai {  get; set; } 

    }
}
