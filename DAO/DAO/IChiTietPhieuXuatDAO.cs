using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface IChiTietPhieuXuatDAO
    {
        long insert(ChiTietPhieuXuat chiTietPhieuXuat);
        void update(ChiTietPhieuXuat chiTietPhieuXuat);
        void delete(int maphieuxuat, int maphienbansp);
        List<ChiTietPhieuXuat> GetByPhieuXuatId(int maphieuxuat);
    }
}
