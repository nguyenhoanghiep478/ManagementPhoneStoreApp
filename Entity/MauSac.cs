using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class MauSac
    {
        private int mamau;
        private string tenmau;
        private bool trangthai;
        public int Mamau
        {
            get {return mamau;}
            set {mamau = value;}
        }
        public string Tenmau
        {
            get {return tenmau;}
            set {tenmau = value;}
        }
        public bool Trangthai
        {
            get {return trangthai;}
            set {trangthai = value;}
        }
        public override string ToString()
        {
            return $"Mamau:{mamau}, Tenmau:{tenmau}, Trangthai:{trangthai}";
        }
    }
}