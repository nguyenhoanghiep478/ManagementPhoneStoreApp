using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongKeNhaCungCapDTO
    {
        int mancc;
        String tenncc;
        int soluong;
        long tongtien;

        public int MaNCC
        {
            get { return mancc; }
            set { mancc = value; }
        }
        public String TenNCC
        {
            get { return tenncc; }
            set { tenncc = value; }
        }

        public int SoLuong
        {
            get { return soluong; } 

            set {  soluong = value; }
        }

        public long Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }
    }
}
