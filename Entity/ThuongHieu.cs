using System;

namespace Entity
{
    public class ThuongHieu
    {
        private int mathuonghieu;
        private string tenthuonghieu;
        private int trangthai;

        public int Mathuonghieu
        {
            get { return mathuonghieu; }
            set { mathuonghieu = value; }
        }

        public string Tenthuonghieu
        {
            get { return tenthuonghieu; }
            set { tenthuonghieu = value; }
        }

        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }

        public override string ToString()
        {
            return $"Mathuonghieu: {mathuonghieu}, Tenthuonghieu: {tenthuonghieu}, Trangthai: {trangthai}";
        }
    }
}