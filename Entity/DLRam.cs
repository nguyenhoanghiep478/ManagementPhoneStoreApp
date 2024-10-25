using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DLRam
    {
        private int madlram;
        private int kichthuocram;
        private bool trangthai;
        public int Madlram
        {
            get {return madlram;}
            set {madlram = value;}
        }
        public int Kichthuocram
        {
            get {return kichthuocram;}
            set {kichthuocram = value;}
        }
        public bool Trangthai
        {
            get {return trangthai;}
            set {trangthai = value;}
        }
        public override string ToString()
        {
            return $"Madlram:{madlram}, Kichthuocram:{kichthuocram}, Trangthai:{trangthai}";
        }
    }
}