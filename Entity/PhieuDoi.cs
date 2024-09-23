using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PhieuDoi
    {
        private int? maphieudoi;
        private string maimei;
        private string lydo;
        private DateTime thoigian;
        private int? nguoitao;
   

        // Constructor mặc định
        public PhieuDoi() { }

        // Constructor đầy đủ
        public PhieuDoi(int? maphieudoi, string maimei, string lydo, DateTime thoigian, int? nguoitao)
        {
            this.maphieudoi = maphieudoi;
            this.maimei = maimei;
            this.lydo = lydo;
            this.thoigian = thoigian;
            this.nguoitao = nguoitao;
        }

        
        public int? Maphieudoi
        {
            get { return maphieudoi; }
            set { maphieudoi = value; }
        }

        // Thuộc tính maimei với get/set đầy đủ
       
        public string Maimei
        {
            get { return maimei; }
            set { maimei = value; }
        }

        // Thuộc tính lydo với get/set đầy đủ
        
        public string Lydo
        {
            get { return lydo; }
            set { lydo = value; }
        }

        // Thuộc tính thoigian với get/set đầy đủ
        
        public DateTime Thoigian
        {
            get { return thoigian; }
            set { thoigian = value; }
        }

        // Thuộc tính nguoitao với get/set đầy đủ
      
        public int? Nguoitao
        {
            get { return nguoitao; }
            set { nguoitao = value; }
        }

        // Phương thức ToString để in thông tin đối tượng
        public override string ToString()
        {
            return $"maphieudoi: {maphieudoi?.ToString() ?? "null"}, " +
                   $"maimei: {maimei}, " +
                   $"lydo: {lydo}, " +
                   $"thoigian: {thoigian.ToString("yyyy-MM-dd HH:mm:ss") ?? "null"}, " +
                   $"nguoitao: {nguoitao?.ToString() ?? "null"}";
        }
    }
}
