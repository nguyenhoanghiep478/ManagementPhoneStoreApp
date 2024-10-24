using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongKeKhachHangDTO
    {
        int makh;
        String tenkh;
        int soluongphieu;
        long tongtien;

        public int MaKH
        {
            get { return makh; }
            set { makh = value; }
        }

        public String TenKH
        {
            get { return tenkh; }
            set { tenkh = value; }
        }

        public int SoLuongPhieu
        {
            get { return soluongphieu; }
            set { soluongphieu = value; }
        }

        public long Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }
    }
}
