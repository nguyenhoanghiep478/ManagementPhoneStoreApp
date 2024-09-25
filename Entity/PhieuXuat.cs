using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity
{
    public class PhieuXuat
    {
        private int? maphieuxuat;
        private DateTime thoigian;
        private long? tongtien;
        private int? nguoitaophieuxuat;
        private int? makh;
        private int? trangthai;

        // Default constructor
        public PhieuXuat() { }

        // Parameterized constructor
        public PhieuXuat(int? maphieuxuat, DateTime thoigian, long? tongtien,
                         int? nguoitaophieuxuat, int? makh, int? trangthai)
        {
            this.maphieuxuat = maphieuxuat;
            this.thoigian = thoigian;
            this.tongtien = tongtien;
            this.nguoitaophieuxuat = nguoitaophieuxuat;
            this.makh = makh;
            this.trangthai = trangthai;
        }

        public int? Maphieuxuat
        {
            get { return maphieuxuat; }
            set { maphieuxuat = value; }
        }

        public DateTime Thoigian
        {
            get { return thoigian; }
            set { thoigian = value; }
        }

        public long? Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }

        public int? Nguoitaophieuxuat
        {
            get { return nguoitaophieuxuat; }
            set { nguoitaophieuxuat = value; }
        }

        public int? Makh
        {
            get { return makh; }
            set { makh = value; }
        }

        public int? Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }

        public override string ToString()
        {
            return $"maphieuxuat: {maphieuxuat?.ToString() ?? "null"}, " +
                   $"thoigian: {thoigian.ToString("yyyy-MM-dd HH:mm:ss")}, " +
                   $"tongtien: {tongtien?.ToString() ?? "null"}, " +
                   $"nguoitaophieuxuat: {nguoitaophieuxuat?.ToString() ?? "null"}, " +
                   $"makh: {makh?.ToString() ?? "null"}, " +
                   $"trangthai: {trangthai?.ToString() ?? "null"}";
        }
    }
}
