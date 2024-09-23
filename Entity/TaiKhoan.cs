using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class TaiKhoan
    {
            private int manv;
            private string matkhau;
            private int? manhomquyen;
            private string tendangnhap;
            private int? trangthai;
            private string otp;

            public int Manv { get => manv; set => manv = value; }
            public string Matkhau { get => matkhau; set => matkhau = value; }
            public int? Manhomquyen { get => manhomquyen; set => manhomquyen = value; }
            public string Tendangnhap { get => tendangnhap; set => tendangnhap = value; }
            public int? Trangthai { get => trangthai; set => trangthai = value; }
            public string Otp { get => otp; set => otp = value; }

        public TaiKhoan()
        {
                
        }

        public TaiKhoan(int manv, string matkhau, int? manhomquyen, string tendangnhap, int? trangthai, string otp)
        {
            Manv = manv;
            Matkhau = matkhau;
            Manhomquyen = manhomquyen;
            Tendangnhap = tendangnhap;
            Trangthai = trangthai;
            Otp = otp;
        }

        public override string ToString()
        {
            return $"Manv: {manv}, " +
                   $"Matkhau: {matkhau}, " +
                   $"Manhomquyen: {manhomquyen?.ToString() ?? "null"}, " +
                   $"Tendangnhap: {tendangnhap}, " +
                   $"Trangthai: {trangthai?.ToString() ?? "null"}, " +
                   $"Otp: {otp}";
        }
    }

     
    
}
