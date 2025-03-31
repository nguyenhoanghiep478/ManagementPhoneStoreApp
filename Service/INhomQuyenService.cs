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
        bool Update(NhomQuyen nhomquyen, List<ChiTietQuyen> chitietquyen, int index,string NewName);
        bool Delete(NhomQuyen nhomquyen);
        List<ChiTietQuyen> GetChiTietQuyen(int manhomquyen);
        bool AddChiTietQuyen(List<ChiTietQuyen> listctquyen);
        bool RemoveChiTietQuyen(int manhomquyen);
        bool CheckPermission(int maquyen, string chucnang, string hanhdong);
        List<NhomQuyen> Search(string type,string text);

        List<DanhMucChucNang> getAllDanhMucChucNang();

        Boolean checkDup(string tenNhomQuyen);
        int getIncreasementId();
        int getIndexByMaNhomQuyen(int maNhomQuyen);
    }
}
