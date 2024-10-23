using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface IChiTietSanPham
    {
        long insert(ChiTietSanPham sanPham);
        void update(ChiTietSanPham sanPham);
        void delete(long id);
        ChiTietSanPham FindByMaImei(string maImei);
        List<ChiTietSanPham> FindByMaPhieuXuat(int maphieuxuat);
        List<ChiTietSanPham> FindByMaPhieuNhap(int maphieunhap);
        List<ChiTietSanPham> FindByPhienBanSanPham(int pbsp);
    }
}
