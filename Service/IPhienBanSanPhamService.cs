using DAO.DAO.impl;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IPhienBanSanPhamService
    {
        List<PhienBanSanPham> GetAll(int masp);
        PhienBanSanPham GetByMaPhienBan(int mapb);
        int GetIndexByMaPhienBan(List<PhienBanSanPham> list, int mapb);
        void GetStringListImei();
        bool CheckDuplicate(List<PhienBanSanPham> listch, PhienBanSanPham ch);
        bool Add(List<PhienBanSanPham> listch);
        int GetSoluong(int maphienban);
        bool CheckImeiExists(List<ChiTietSanPham> arr);
    }
}
