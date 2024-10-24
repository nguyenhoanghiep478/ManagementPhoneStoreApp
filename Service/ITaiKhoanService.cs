using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ITaiKhoanService
    {
        List<TaiKhoan> GetTaiKhoanAll();
        TaiKhoan GetTaiKhoan(int index);
        int GetTaiKhoanByMaNV(int manv);
        NhomQuyen GetNhomQuyen(int manhom);
        void AddAcc(TaiKhoan tk);
        void UpdateAcc(int index, TaiKhoan tk);
        void DeleteAcc(int manv);
        List<TaiKhoan> Search(string txt, string type);
    }
}
