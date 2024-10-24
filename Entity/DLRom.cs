using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DLRom
    {
        private int madlrom;
        private int kichthuocrom;
        private bool trangthai;
        public int Madlrom
        {
            get {return madlrom;}
            set {madlrom = value;}
        }
        public int Kichthuocrom
        {
            get {return kichthuocrom;}
            set {kichthuocrom = value;}
        }
        public bool Trangthai
        {
            get {return trangthai;}
            set {trangthai = value;}
        }
        public override string ToString()
        {
            return $"Madlrom:{madlrom}, Kichthuocrom:{kichthuocrom}, Trangthai:{trangthai}";
        }
    }
}