using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HeDieuHanh
    {
        private int? mahedieuhanh;
        private string tenhedieuhanh;
        private int? trangthai;

        public int? Mahedieuhanh { get => mahedieuhanh; set => mahedieuhanh = value; }
        public string Tenhedieuhanh { get => tenhedieuhanh; set => tenhedieuhanh = value; }
        public int? Trangthai { get => trangthai; set => trangthai = value; }

        public override string ToString()
        {
            return $"mahedieuhanh: {Mahedieuhanh}, tenhedieuhanh: {Tenhedieuhanh}, trangthai: {Trangthai}";
        }
    }
}
