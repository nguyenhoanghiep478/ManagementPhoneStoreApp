using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NhomQuyen
    {
        private int? manhomquyen;
        private string tennhomquyen;
        private int? trangthai;

        public int? Manhomquyen { get => manhomquyen; set => manhomquyen = value; }
        public string Tennhomquyen { get => tennhomquyen; set => tennhomquyen = value; }
        public int? Trangthai { get => trangthai; set => trangthai = value; }

        public override string ToString()
        {
            return $"manhomquyen: {Manhomquyen}, tennhomquyen: {Tennhomquyen}, trangthai: {Trangthai}";
        }
    }
}
