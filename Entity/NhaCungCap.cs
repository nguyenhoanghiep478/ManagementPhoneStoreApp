using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NhaCungCap
    {
        private int manhacungcap;
        private string tennhacungcap;
        private string diachi;
        private string email;
        private string sdt;
        private int trangthai;

        public int Manhacungcap
        {
            get { return manhacungcap; }
            set { manhacungcap = value; }
        }

        public string Tennhacungcap
        {
            get { return tennhacungcap; }
            set { tennhacungcap = value; }  // Đã sửa
        }

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }

        public override string ToString()
        {
            return $"Manhacungcap: {manhacungcap}, Tennhacungcap: {tennhacungcap}, Diachi: {diachi}, Email: {email}, Sdt: {sdt}, Trangthai: {trangthai}";
        }
    }
}
