using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Entity
{
    public class ChiTietPhieuXuat
    {
        private int maphieuxuat;
        private int maphienbansp;
        private int soluong;
        private int dongia;

        // Default constructor
        public ChiTietPhieuXuat() { }

        // Parameterized constructor
        public ChiTietPhieuXuat(int maphieuxuat, int maphienbansp, int soluong, int dongia)
        {
            this.maphieuxuat = maphieuxuat;
            this.maphienbansp = maphienbansp;
            this.soluong = soluong;
            this.dongia = dongia;
        }

        public int Maphieuxuat
        {
            get { return maphieuxuat; }
            set { maphieuxuat = value; }
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

        public override string ToString()
        {
            return $"maphieuxuat: {maphieuxuat}, maphienbansp: {maphienbansp}, soluong: {soluong}, dongia: {dongia}";
        }
    }
}
