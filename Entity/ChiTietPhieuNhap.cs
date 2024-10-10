using System;

namespace Entity
{
    public class ChiTietPhieuNhap
    {
        private int maphieunhap;
        private int maphienbansp;
        private int soluong;
        private int dongia;
        private int hinhthucnhap;

        public int Maphieunhap
        {
            get { return maphieunhap; }
            set { maphieunhap = value; }
        }

        public int Maphienbansp
        {
            get { return maphienbansp; }
            set { maphienbansp = value; }
        }

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }

        public int Dongia
        {
            get { return dongia; }
            set { dongia = value; }
        }

        public int Hinhthucnhap
        {
            get { return hinhthucnhap; }
            set { hinhthucnhap = value; }
        }

        public override string ToString()
        {
            return $"Maphieunhap: {maphieunhap}, Maphienbansp: {maphienbansp}, Soluong: {soluong}, Dongia: {dongia}, Hinhthucnhap: {hinhthucnhap}";
        }
    }
}
