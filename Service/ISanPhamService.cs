using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ISanPhamService
    {
        List<SanPham> GetAll();
        SanPham GetByIndex(int index);
        SanPham GetByMaSP(int masp);
        int GetIndexByMaSP(int masanpham);
        bool Add(SanPham sp, List<PhienBanSanPham> listch);
        bool Delete(SanPham sp);
        bool Update(SanPham sp);
        List<SanPham> GetByMakhuvuc(int makv);
        List<SanPham> Search(string text);
        SanPham GetSp(int mapb);
        int GetQuantity();
    }
}
