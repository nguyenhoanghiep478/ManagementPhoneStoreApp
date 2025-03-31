using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entity
{
    public class ChiTietQuyen
    {
        public int MaNhomQuyen { get; set; }
        public string MaChucNang { get; set; }
        public string HanhDong { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ChiTietQuyen other)
            {
                return this.MaNhomQuyen == other.MaNhomQuyen && this.MaChucNang == other.MaChucNang && this.HanhDong == other.HanhDong;
            }
            return false;
        }
    }
}
