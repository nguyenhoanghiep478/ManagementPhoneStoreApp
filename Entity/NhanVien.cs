using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NhanVien
    {
        private int manv;
        private string hoten;
        private int? giotinh;
        private DateTime ngaysinh;
        private string sdt;
        private string email;
        private int? trangthai;

        public NhanVien(int manv, string hoten, int? giotinh, DateTime ngaysinh, string sdt, string email, int? trangthai)
        {
            this.manv = manv;
            this.hoten = hoten;
            this.giotinh = giotinh;
            this.ngaysinh = ngaysinh;
            this.sdt = sdt;
            this.email = email;
            this.trangthai = trangthai;
        }
        public NhanVien() { }

        public int Manv
        {
            get { return manv; }
            set { manv = value; }
        }

        public string Hoten
        {
            get { return hoten; }
            set { hoten = value; }
        }

        public int? Giotinh
        {
            get { return giotinh; }
            set { giotinh = value; }
        }

        public DateTime Ngaysinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int? Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }

        // ToString Method
        public override string ToString()
        {
            return $"Manv: {manv}, Hoten: {hoten}, Giotinh: {giotinh}, Ngaysinh: {ngaysinh.ToString("dd/MM/yyyy")}, Sdt: {sdt}, Email: {email}, Trangthai: {trangthai}";
        }

    }
}
