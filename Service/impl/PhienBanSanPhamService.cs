using DAO.DAO;
using DAO.DAO.impl;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.impl
{
    public class PhienBanSanPhamService : IPhienBanSanPhamService

    {
        public static PhienBanSanPhamService Instance => instance.Value;

        private readonly IPhienBanSanPham cauhinhDAO = new PhienBanSanPhamDAO();
        private readonly IChiTietSanPham chiTietSanPham = new ChiTietSanPhamDAO();

        private static readonly Lazy<PhienBanSanPhamService> instance = new Lazy<PhienBanSanPhamService>(() => new PhienBanSanPhamService());

        public bool Add(List<PhienBanSanPham> listch) 
        {
            throw new NotImplementedException();
        }

        public bool CheckDuplicate(List<PhienBanSanPham> listch, PhienBanSanPham ch)
        {
            throw new NotImplementedException();
        }

        public bool CheckImeiExists(List<ChiTietSanPham> arr)
        {
            return cauhinhDAO.CheckImeiExists(arr);
        }

        public List<PhienBanSanPham> GetAll(int masp)
        {
            return cauhinhDAO.FindByMaSp(masp.ToString());
        }

        public PhienBanSanPham GetByMaPhienBan(int mapb)
        {
            return cauhinhDAO.FindByMaPhienBanSanPham(mapb);
        }

        public int GetIndexByMaPhienBan(List<PhienBanSanPham> list, int mapb)
        {
            return list.FindIndex(pb => pb.MaPhienBanSanPham == mapb);
        }

        public int GetSoluong(int maphienban)
        {
            return cauhinhDAO.FindByMaPhienBanSanPham(maphienban).SoLuongTon;
        }

        public void GetStringListImei()
        {
            throw new NotImplementedException();
        }
    }
}
