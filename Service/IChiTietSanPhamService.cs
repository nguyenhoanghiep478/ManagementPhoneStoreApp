using DAO.DAO.impl;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IChiTietSanPhamService
    {
        List<ChiTietSanPham> getAllByMaPBSP(int pbsp); //get all chi tiet san pham by mã phiên bản sản phẩm
        List<ChiTietSanPham> getAll();
        ChiTietSanPham getByIndex(int index);
        List<ChiTietSanPham> getAllByMaSp(int masp);
        Dictionary<int, List<ChiTietSanPham>> getChiTietSanPhamByMaPN(int maphieunhap); // get all chi tiet san pham by mã phiếu nhập
        Dictionary<int, List<ChiTietSanPham>> getChiTietSanPhamByMaPX(int maphieuxuat); //get all chi tiet san pham by mã phiếu xuất
        List<ChiTietSanPham> findByPhienBanAndTinhTrangAndImeiAndMaSp(String imei, int masp, int pbsp,bool tinhtrang); //get all chi tiet san pham by masp , imei,pbsp,tinh trang
        List<ChiTietSanPham> findByPhienBanAndImeiAndMaSp(String imei, int masp, int pbsp); //get all chi tiet san pham by masp , imei,pbsp


    }
}
