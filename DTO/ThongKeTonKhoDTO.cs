using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongKeTonKhoDTO
    {   
        public ThongKeTonKhoDTO(int masp,int mapbsp,string tensanpham,int ram,int rom, string mausac,int tonDauKy,int nhapTrongKy,int xuatTrongKy,int tonCuoiKy) {
        
            this.Masp= masp;
            this.Maphienbansp = mapbsp;
            this.Tensanpham= tensanpham;    
            this.Ram= ram;
            this.Rom= rom;  
            this.Mausac= mausac;
            this.Toncuoiky= tonDauKy;
            this.Nhaptrongky= nhapTrongKy;
            this.Xuattrongky= xuatTrongKy;
            this.Toncuoiky = tonCuoiKy;
        }
        public int Masp { get; set; }
        public int Maphienbansp { get; set; }
        public string Tensanpham { get; set; }
        public int Ram { get; set; }
        public int Rom { get; set; }
        public string Mausac { get; set; }
        public int Tondauky { get; set; }
        public int Nhaptrongky { get; set; }
        public int Xuattrongky { get; set; }
        public int Toncuoiky { get; set; }


    }
}
