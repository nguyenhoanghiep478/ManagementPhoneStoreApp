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
        List<ChiTietSanPham> getChiTietSanPhamByMaPN(int maphieunhap); // get all chi tiet san pham by mã phiếu nhập
        List<ChiTietSanPham> getChiTietSanPhamByMaPX(int maphieuxuat); //get all chi tiet san pham by mã phiếu xuất
        List<ChiTietSanPham> findByPhienBanAndTinhTrangAndImeiAndMaSp(String imei, int masp, int pbsp,int tinhtrang); //get all chi tiet san pham by masp , imei,pbsp,tinh trang
        List<ChiTietSanPham> findByPhienBanAndImeiAndMaSp(String imei, int masp, int pbsp); //get all chi tiet san pham by masp , imei,pbsp


    }
}
