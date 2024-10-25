using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ChiTietPhieu
    {
        private int maphieu;
        private int maphienbansp;
        private int soluong;
        private int dongia;

        public int MaPhieu
        {
            get { return maphieu; }
            set { maphieu = value; }
        }
        public int MaPhienBanSanPham
        {
            get { return maphienbansp; }
            set { maphienbansp = value; }
        }

        public int SoLuong
        {
            get { return soluong; }
            set { soluong = value; }
        }

        public int Dongia
        {
            get { return dongia; }
            set { dongia = value; }
        }
    }
}
