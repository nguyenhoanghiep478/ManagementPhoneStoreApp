using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface IPhienBanSanPham
    {
        long insert(PhienBanSanPham sanPham);
        void update(PhienBanSanPham sanPham);
        void delete(long id);
        PhienBanSanPham FindByMaPhienBanSanPham(int maphienban);
    }
}
