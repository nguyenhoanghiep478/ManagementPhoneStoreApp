using DAO.DAO;
using DAO.DAO.impl;
using Entity;
using State.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.impl
{
    public class ChiTietSanPhamService : IChiTietSanPhamService
    {
        private readonly IChiTietSanPham chiTietSanPhamDao = new ChiTietSanPhamDAO();
        private readonly IPhienBanSanPhamService pbspService;

        private static readonly Lazy<ChiTietSanPhamService> instance = new Lazy<ChiTietSanPhamService>();

        private ChiTietSanPhamService()
        {
            listpbsp = pbspService.GetAll(0);
            listctsp = new List<ChiTietSanPham>();
        }

        public static ChiTietSanPhamService Instance => instance.Value;

        private List<PhienBanSanPham> listpbsp;
        private List<ChiTietSanPham> listctsp;

        public List<ChiTietSanPham> findByPhienBanAndImeiAndMaSp(string imei, int masp, int pbsp)
        {
            List<ChiTietSanPham> list = getAllByMaSp(masp);
            return list.Where(i => i.MaPhienBanSanPham == pbsp && i.MaImei.Contains(imei)).ToList();
        }

        public List<ChiTietSanPham> getAllByMaSp(int masp)
        {
            var list2 = new List<ChiTietSanPham>();
            var list = pbspService.GetAll(masp);
            foreach (var item in list)
            {
                var ctsptemp = getAllByMaPBSP(item.MaPhienBanSanPham);
                list2.AddRange(ctsptemp);
            }
            return list2;
        }

        public List<ChiTietSanPham> findByPhienBanAndTinhTrangAndImeiAndMaSp(string imei, int masp, int pbsp, bool tinhtrang)
        {
            var list = getAllByMaSp(masp);
            return list.Where(i => i.MaPhienBanSanPham == pbsp && i.TinhTrang == tinhtrang && i.MaImei.Contains(imei)).ToList();
        }

        public List<ChiTietSanPham> getAll()
        {
            return this.listctsp;
        }

        public List<ChiTietSanPham> getAllByMaPBSP(int pbsp)
        {
            listctsp = chiTietSanPhamDao.FindByPhienBanSanPham(pbsp);
            return listctsp;
        }

        public Dictionary<int, List<ChiTietSanPham>> getChiTietSanPhamByMaPN(int maphieunhap)
        {
            var chitietsp = chiTietSanPhamDao.FindByMaPhieuNhap(maphieunhap);
            var result = new Dictionary<int, List<ChiTietSanPham>>();

            foreach (var item in chitietsp)
            {
                if (!result.ContainsKey(item.MaPhienBanSanPham))
                {
                    result[item.MaPhienBanSanPham] = new List<ChiTietSanPham>();
                }
            }

            foreach (var item in chitietsp)
            {
                result[item.MaPhienBanSanPham].Add(item);
            }

            return result;
        }

        public Dictionary<int, List<ChiTietSanPham>> getChiTietSanPhamByMaPX(int maphieuxuat)
        {
            var chitietsp = chiTietSanPhamDao.FindByMaPhieuXuat(maphieuxuat);
            var result = new Dictionary<int, List<ChiTietSanPham>>();

            foreach (var item in chitietsp)
            {
                if (!result.ContainsKey(item.MaPhienBanSanPham))
                {
                    result[item.MaPhienBanSanPham] = new List<ChiTietSanPham>();
                }
            }

            foreach (var item in chitietsp)
            {
                result[item.MaPhienBanSanPham].Add(item);
            }

            return result;
        }

        public ChiTietSanPham getByIndex(int index)
        {
            return this.listctsp[index];
        }
    }
}
