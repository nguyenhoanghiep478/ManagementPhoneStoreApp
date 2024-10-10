using System;

namespace Entity
{
    public class PhieuNhap
    {
        private int maphieunhap;
        private DateTime thoigian;
        private int manhacungcap;
        private string nguoitao;
        private long tongtien;
        private int trangthai;

        public int Maphieunhap
        {
            get { return maphieunhap; }
            set { maphieunhap = value; }
        }

        public DateTime Thoigian
        {
            get { return thoigian; }
            set { thoigian = value; }
        }

        public int Manhacungcap
        {
            get { return manhacungcap; }
            set { manhacungcap = value; }
        }

        public string Nguoitao
        {
            get { return nguoitao; }
            set { nguoitao = value; }
        }

        public long Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }

        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }

        public override string ToString()
        {
            return $"Maphieunhap: {maphieunhap}, Thoigian: {thoigian}, Manhacungcap: {manhacungcap}, Nguoitao: {nguoitao}, Tongtien: {tongtien}, Trangthai: {trangthai}";
        }
    }
}
