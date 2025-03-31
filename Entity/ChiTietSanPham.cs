using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ChiTietSanPham
    {
        public string MaImei { get; set; }

        public int MaPhienBanSanPham { get; set; }

        public int MaPhieuNhap { get; set; }

        public int? MaPhieuXuat { get; set; }

        public bool TinhTrang { get; set; }
        public ChiTietSanPham(string maImei, int maPhienBanSanPham, int maPhieuNhap, int? maPhieuXuat, bool tinhTrang)
        {
            MaImei = maImei;
            MaPhienBanSanPham = maPhienBanSanPham;
            MaPhieuNhap = maPhieuNhap;
            MaPhieuXuat = maPhieuXuat;
            TinhTrang = tinhTrang;
        }
        public ChiTietSanPham() { }

    }
}
