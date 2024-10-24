using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface INhaCungCapService
    {
        List<NhaCungCap> GetAll();
        NhaCungCap GetByIndex(int index);
        bool Add(NhaCungCap ncc);
        bool Delete(NhaCungCap ncc, int index);
        bool Update(NhaCungCap ncc);
        int GetIndexByMaNCC(int mancc);
        List<NhaCungCap> Search(string txt, string type);
        string[] GetArrTenNhaCungCap();
        string GetTenNhaCungCap(int mancc);
        NhaCungCap FindCT(List<NhaCungCap> ncc, string tenncc);
    }
}
