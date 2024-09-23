using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    internal interface IChiTietSanPham
    {
        long insert(ChiTietSanPham sanPham);
        void update(ChiTietSanPham sanPham);
        void delete(long id);
        List<ChiTietSanPham> FindByMaImei(string maImei);
    }
}
