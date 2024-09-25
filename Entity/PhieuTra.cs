using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity
{
    public class PhieuTra
    {
        private int? maphieutra;
        private string maimei;
        private string lydo;
        private DateTime thoigian;
        private int nguoitao;

        // Constructor mặc định
        public PhieuTra() { }

        // Constructor đầy đủ
        public PhieuTra(int? maphieutra, string maimei, string lydo, DateTime thoigian, int nguoitao)
        {
            this.maphieutra = maphieutra;
            this.maimei = maimei;
            this.lydo = lydo;
            this.thoigian = thoigian;
            this.nguoitao = nguoitao;
        }

        public int? Maphieutra
        {
            get { return maphieutra; }
            set { maphieutra = value; }
        }

        public string Maimei
        {
            get { return maimei; }
            set { maimei = value; }
        }

        public string Lydo
        {
            get { return lydo; }
            set { lydo = value; }
        }

        public DateTime Thoigian
        {
            get { return thoigian; }
            set { thoigian = value; }
        }

        public int Nguoitao
        {
            get { return nguoitao; }
            set { nguoitao = value; }
        }

        public override string ToString()
        {
            return $"maphieutra: {maphieutra?.ToString() ?? "null"}, " +
                   $"maimei: {maimei}, " +
                   $"lydo: {lydo}, " +
                   $"thoigian: {thoigian.ToString("yyyy-MM-dd HH:mm:ss")}, " +
                   $"nguoitao: {nguoitao}";
        }
    }
}
