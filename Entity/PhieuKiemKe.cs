using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PhieuKiemKe
    {
       
        private int? maphieu ;
        private DateTime? thoigian;
        private int? nguoitaophieukiemke;

        public int? Maphieu { get => maphieu; set => maphieu = value; }
        public DateTime? Thoigian { get => thoigian; set => thoigian = value; }
        public int? Nguoitaophieukiemke { get => nguoitaophieukiemke; set => nguoitaophieukiemke = value; }

        public override string ToString()
        {
            return $"maphieu: {Maphieu}, thoigian: {Thoigian}, nguoitaophieukiemke: {Nguoitaophieukiemke}";
        }
    }
}
