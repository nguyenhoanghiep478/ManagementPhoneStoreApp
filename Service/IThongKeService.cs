using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IThongKeService
    {
        List<ThongKeKhachHangDTO> GetAllKhachHang();
        List<ThongKeKhachHangDTO> FilterKhachHang(string text, DateTime start, DateTime end);
        List<ThongKeNhaCungCapDTO> GetAllNCC();
        List<ThongKeNhaCungCapDTO> FilterNCC(string text, DateTime start, DateTime end);
        Dictionary<int, List<ThongKeTonKhoDTO>> GetTonKho();
        Dictionary<int, List<ThongKeTonKhoDTO>> FilterTonKho(string text, DateTime time_start, DateTime time_end);
        int[] GetSoluong(List<ThongKeTonKhoDTO> list);
        List<ThongKeDoanhThuDTO> GetDoanhThuTheoTungNam(int year_start, int year_end);
        List<ThongKeTheoThangDTO> GetThongKeTheoThang(int nam);
        List<ThongKeTungNgayTrongThangDTO> GetThongKeTungNgayTrongThang(int thang, int nam);
        List<ThongKeTungNgayTrongThangDTO> GetThongKeTuNgayDenNgay(string start, string end);
        List<ThongKeTungNgayTrongThangDTO> GetThongKe7NgayGanNhat();
    }
}
