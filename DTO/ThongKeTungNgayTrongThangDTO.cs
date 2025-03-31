using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongKeTungNgayTrongThangDTO
    {
        public DateTime Ngay { get; set; } 
        public int Chiphi { get; set; }     
        public int DoanhthuNgay { get; set; }  
        public int LoinhuanNgay { get; set; }

        public ThongKeTungNgayTrongThangDTO(string ngay,int chiphi,int doanhThuNgay,int LoinhuanNgay) {
            this.Ngay = DateTime.Parse(ngay);
            this.Chiphi = chiphi;
            this.DoanhthuNgay = doanhThuNgay;
            this.LoinhuanNgay = LoinhuanNgay;
        }

        public ThongKeTungNgayTrongThangDTO(DateTime ngay, int chiphi, int doanhThuNgay, int LoinhuanNgay)
        {
            this.Ngay = ngay;
            this.Chiphi = chiphi;
            this.DoanhthuNgay = doanhThuNgay;
            this.LoinhuanNgay = LoinhuanNgay;
        }

        public ThongKeTungNgayTrongThangDTO() { }
    }
}
