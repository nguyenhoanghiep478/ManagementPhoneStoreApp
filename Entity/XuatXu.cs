using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class XuatXu
    {
        private int maxuatxu;
        private string tenxuatxu;
        private bool trangthai;
        public int Maxuatxu
        {
            get {return maxuatxu;}
            set {maxuatxu = value;}
        }
        public string Tenxuatxu
        {
            get {return tenxuatxu;}
            set {tenxuatxu = value;}
        }
        public bool Trangthai
        {
            get {return trangthai;}
            set {trangthai = value;}
        }
        public override string ToString()
        {
            return $"Maxuatxu: {maxuatxu}, Tenxuatxu: {tenxuatxu}, Trangthai: {trangthai}";
        }
    }
}