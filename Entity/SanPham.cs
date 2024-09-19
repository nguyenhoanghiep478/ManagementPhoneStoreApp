using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{    
        public class SanPham
        {
            private int masp;
            private string tensp;
            private string hinhanh;
            private int? xuatxu;
            private string chipxuly;
            private int? dungluongpin;
            private double? kichthuocman;
            private int? hedieuhanh;
            private int? phienbanhdh;
            private string camerasau;
            private string cameratruoc;
            private int? thoigianbaohanh;
            private int? thuonghieu;
            private int? khuvuckho;
            private int soluongton;
            private bool trangthai;

            // Public properties with getters and setters
            public int Masp
            {
                get { return masp; }
                set { masp = value; }
            }

            public string Tensp
            {
                get { return tensp; }
                set { tensp = value; }
            }

            public string Hinhanh
            {
                get { return hinhanh; }
                set { hinhanh = value; }
            }

            public int? Xuatxu
            {
                get { return xuatxu; }
                set { xuatxu = value; }
            }

            public string Chipxuly
            {
                get { return chipxuly; }
                set { chipxuly = value; }
            }

            public int? Dungluongpin
            {
                get { return dungluongpin; }
                set { dungluongpin = value; }
            }

            public double? Kichthuocman
            {
                get { return kichthuocman; }
                set { kichthuocman = value; }
            }

            public int? Hedieuhanh
            {
                get { return hedieuhanh; }
                set { hedieuhanh = value; }
            }

            public int? Phienbanhdh
            {
                get { return phienbanhdh; }
                set { phienbanhdh = value; }
            }

            public string Camerasau
            {
                get { return camerasau; }
                set { camerasau = value; }
            }

            public string Cameratruoc
            {
                get { return cameratruoc; }
                set { cameratruoc = value; }
            }

            public int? Thoigianbaohanh
            {
                get { return thoigianbaohanh; }
                set { thoigianbaohanh = value; }
            }

            public int? Thuonghieu
            {
                get { return thuonghieu; }
                set { thuonghieu = value; }
            }

            public int? Khuvuckho
            {
                get { return khuvuckho; }
                set { khuvuckho = value; }
            }

            public int Soluongton
            {
                get { return soluongton; }
                set { soluongton = value; }
            }

            public bool Trangthai
            {
                get { return trangthai; }
                set { trangthai = value; }
            }

            public override string ToString()
            {
                return $"Masp: {masp}, Tensp: {tensp}, Hinhanh: {hinhanh}, Xuatxu: {xuatxu}, Chipxuly: {chipxuly}, Dungluongpin: {dungluongpin}, Kichthuocman: {kichthuocman}, Hediuhanh: {hedieuhanh}, Phienbanhdh: {phienbanhdh}, Camerasau: {camerasau}, Cameratruoc: {cameratruoc}, Thoigianbaohanh: {thoigianbaohanh}, Thuonghieu: {thuonghieu}, Khuvuckho: {khuvuckho}, Soluongton: {soluongton}, Trangthai: {trangthai}";
            }
        }
    
}
