using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IThuongHieuService
    {

        List<ThuongHieu> GetAll();
        ThuongHieu GetByIndex(int index);
        int GetIndexByMaLH(int maloaihang);
        bool Add(ThuongHieu th);
        bool Delete(ThuongHieu lh);
        bool Update(ThuongHieu lh);
        List<ThuongHieu> Search(string text);
        string[] GetArrTenThuongHieu();
        string GetTenThuongHieu(int mathuonghieu);
        bool CheckDup(string name);
    }
}
