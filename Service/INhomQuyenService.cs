using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface INhomQuyenService
    {
        List<NhomQuyen> GetAll();
        NhomQuyen GetByIndex(int index);
        bool Add(string tennhomquyen, List<ChiTietQuyen> ctquyen);
        bool Update(NhomQuyen nhomquyen, List<ChiTietQuyen> chitietquyen, int index);
        bool Delete(NhomQuyen nhomquyen);
        List<ChiTietQuyen> GetChiTietQuyen(string manhomquyen);
        bool AddChiTietQuyen(List<ChiTietQuyen> listctquyen);
        bool RemoveChiTietQuyen(string manhomquyen);
        bool CheckPermission(int maquyen, string chucnang, string hanhdong);
        List<NhomQuyen> Search(string text);
    }
}
