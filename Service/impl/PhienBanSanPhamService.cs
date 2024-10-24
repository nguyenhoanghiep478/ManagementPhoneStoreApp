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
            bool check = false;
            foreach(PhienBanSanPham phienbansp in listch){
                 check = cauhinhDAO.insert(phienbansp) != 0;
            }
           
            return check;
        }

        public bool CheckDuplicate(List<PhienBanSanPham> listch, PhienBanSanPham ch)
        {
            return listch.Any(pb => pb.Equals(ch));
        }

        public bool CheckImeiExists(List<ChiTietSanPham> arr)
        {   
            List<long> imeis = arr.Select(x => long.Parse(x.MaImei)).ToList();
            return chiTietSanPham.checkImeiExists(imeis);
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
