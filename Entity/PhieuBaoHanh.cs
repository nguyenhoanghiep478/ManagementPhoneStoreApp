using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PhieuBaoHanh
    {
        private int? maphieubaohanh;
        private string maimei;
        private string lydo;
        private DateTime thoigian;
        private DateTime? thoigiantra;

      
        public PhieuBaoHanh() { }

      
        public PhieuBaoHanh(int? maphieubaohanh, string maimei, string lydo, DateTime thoigian, DateTime? thoigiantra)
        {
            this.maphieubaohanh = maphieubaohanh;
            this.maimei = maimei;
            this.lydo = lydo;
            this.thoigian = thoigian;
            this.thoigiantra = thoigiantra;
        }

   
        public int? Maphieubaohanh
        {
            get { return maphieubaohanh; }
            set { maphieubaohanh = value; }
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


        public DateTime? Thoigiantra
        {
            get { return thoigiantra; }
            set { thoigiantra = value; }
        }

     
        public override string ToString()
        {
            return $"maphieubaohanh: {maphieubaohanh?.ToString() ?? "null"}, " +
                   $"maimei: {maimei}, " +
                   $"lydo: {lydo}, " +
                   $"thoigian: {thoigian.ToString("yyyy-MM-dd HH:mm:ss")}, " +
                   $"thoigiantra: {thoigiantra?.ToString("yyyy-MM-dd HH:mm:ss") ?? "null"}";
        }
    }
}
