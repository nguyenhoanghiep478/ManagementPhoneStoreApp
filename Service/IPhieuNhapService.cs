using DAO.DAO.impl;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IPhieuNhapService
    {
        List<PhieuNhap> GetAll();
        List<PhieuNhap> GetAllList();
        List<ChiTietSanPham> ConvertHashMapToArray(Dictionary<int, List<ChiTietSanPham>> chitietsanpham);
        List<ChiTietPhieuNhap> GetChiTietPhieu(int maphieunhap);
        List<ChiTietPhieu> GetChiTietPhieu_Type(int maphieunhap);
        bool Add(PhieuNhap phieu, List<ChiTietPhieuNhap> ctPhieu, Dictionary<int, List<ChiTietSanPham>> chitietsanpham);
        ChiTietPhieuNhap FindCT(List<ChiTietPhieuNhap> ctphieu, int mapb);
        long GetTongTien(List<ChiTietPhieuNhap> ctphieu);
        List<PhieuNhap> FilterPhieuNhap(int type, string input, int mancc, int manv, DateTime time_s, DateTime time_e, string price_min, string price_max);
        bool CheckCancelPn(int maphieu);
        int CancelPhieuNhap(int maphieu);
    }
}
