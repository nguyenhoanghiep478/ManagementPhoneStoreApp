using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class KhachHang
    {
        private int? makh;
        private string tenkhachhang;
        private string diachi;
        private string sdt;
        private int? trangthai;
        private DateTime ngaythamgia;

        // Constructor mặc định
        public KhachHang() { }

        // Constructor đầy đủ
        public KhachHang(int? makh, string tenkhachhang, string diachi, string sdt, int? trangthai, DateTime ngaythamgia)
        {
            this.makh = makh;
            this.tenkhachhang = tenkhachhang;
            this.diachi = diachi;
            this.sdt = sdt;
            this.trangthai = trangthai;
            this.ngaythamgia = ngaythamgia;
        }

        public int? MakH
        {
            get { return makh; }
            set { makh = value; }
        }

        public string TenKhachHang
        {
            get { return tenkhachhang; }
            set { tenkhachhang = value; }
        }

        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        public int? TrangThai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        public DateTime NgayThamGia // Phương thức get và set cho ngày tham gia
        {
            get { return ngaythamgia; }
            set { ngaythamgia = value; }
        }

        // Phương thức ToString để in thông tin đối tượng
        public override string ToString()
        {
            return $"makh: {makh?.ToString() ?? "null"}, " +
                   $"tenkhachhang: {tenkhachhang}, " +
                   $"diachi: {diachi}, " +
                   $"sdt: {sdt}, " +
                   $"trangthai: {trangthai?.ToString() ?? "null"}, " +
                   $"ngaythamgia: {ngaythamgia.ToString("yyyy-MM-dd HH:mm:ss") ?? "null"}";
        }
    }
}
