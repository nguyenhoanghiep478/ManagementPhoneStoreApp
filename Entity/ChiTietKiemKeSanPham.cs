using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ChiTietKiemKeSanPham
    {
        private int maphieukiemke;
        private int maphienban;
        private String maimei;
        private int trangthai;

        public int MaPhieuKiemKe
        {
            get { return maphieukiemke; }
            set { maphieukiemke = value; }
        }
        public int MaPhienBan
        {
            get { return maphienban; }
            set { maphienban = value; }
        }

        public String MaImei
        {
            get { return maimei; }
            set { maimei = value; }
        }

        public int TrangThai
        {
            get { return trangthai; }
            set {  trangthai = value; }
        }
    }
}
