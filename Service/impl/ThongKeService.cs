using DTO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.DAO;
using DAO.DAO.impl;
using Entity;
using System.IO;

namespace Service
{
    public class ThongKeService : IThongKeService
    {
        private ThongKeDAO thongkeDAO = new ThongKeDAO();
        private List<ThongKeKhachHangDTO> tkkh;
        private List<ThongKeNhaCungCapDTO> tkncc;
        private Dictionary<int, List<ThongKeTonKhoDTO>> listTonKho;

        public List<ThongKeKhachHangDTO> GetAllKhachHang()
        {
            tkkh = ThongKeDAO.GetThongKeKhachHang("", DateTime.MinValue, DateTime.Now);
            return tkkh;
        }

        public List<ThongKeKhachHangDTO> FilterKhachHang(string text, DateTime start, DateTime end)
        {
            tkkh = ThongKeDAO.GetThongKeKhachHang(text, start, end);
            return tkkh;
        }

        public List<ThongKeNhaCungCapDTO> GetAllNCC()
        {
            tkncc = ThongKeDAO.GetThongKeNCC("", DateTime.MinValue, DateTime.Now);
            return tkncc;
        }

        public List<ThongKeNhaCungCapDTO> FilterNCC(string text, DateTime start, DateTime end)
        {
            tkncc = ThongKeDAO.GetThongKeNCC(text, start, end);
            return tkncc;
        }

        public Dictionary<int, List<ThongKeTonKhoDTO>> GetTonKho()
        {
            return listTonKho;
        }

        public Dictionary<int, List<ThongKeTonKhoDTO>> FilterTonKho(string text, DateTime timeStart, DateTime timeEnd)
        {
            var result = ThongKeDAO.GetThongKeTonKho(text, timeStart, timeEnd);
            return result;
        }

        public int[] GetSoluong(List<ThongKeTonKhoDTO> list)
        {
            int[] result = { 0, 0, 0, 0 };
            foreach (var item in list)
            {
                result[0] += item.Tondauky;
                result[1] += item.Nhaptrongky;
                result[2] += item.Xuattrongky;
                result[3] += item.Toncuoiky;
            }
            return result;
        }

        public List<ThongKeDoanhThuDTO> GetDoanhThuTheoTungNam(int yearStart, int yearEnd)
        {
            return thongkeDAO.GetDoanhThuTheoTungNam(yearStart, yearEnd);
        }

        public List<ThongKeTheoThangDTO> GetThongKeTheoThang(int nam)
        {
            return thongkeDAO.GetThongKeTheoThang(nam);
        }

        public List<ThongKeTungNgayTrongThangDTO> GetThongKeTungNgayTrongThang(int thang, int nam)
        {
            return thongkeDAO.GetThongKeTungNgayTrongThang(thang, nam);
        }

        public List<ThongKeTungNgayTrongThangDTO> GetThongKeTuNgayDenNgay(string start, string end)
        {
            return thongkeDAO.GetThongKeTuNgayDenNgay(start, end);
        }

        public List<ThongKeTungNgayTrongThangDTO> GetThongKe7NgayGanNhat()
        {
            return thongkeDAO.GetThongKe7NgayGanNhat();
        }
    }
}