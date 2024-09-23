using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class KhuVucKho
    {
        private int? makhuvuc;
        private string tenkhuvuc;
        private string ghichu;
        private int? trangthai;

        public int? Makhuvuc { get => makhuvuc; set => makhuvuc = value; }
        public string Tenkhuvuc { get => tenkhuvuc; set => tenkhuvuc = value; }
        public string Ghichu { get => ghichu; set => ghichu = value; }
        public int? Trangthai { get => trangthai; set => trangthai = value; }

        public override string ToString()
        {
            return $"makhuvuc: {Makhuvuc}, tenkhuvuc: {Tenkhuvuc}, ghichu: {Ghichu}, trangthai: {Trangthai}";
        }
    }
}
