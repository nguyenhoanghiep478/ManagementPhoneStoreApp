using DAO.DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IPhieuKiemKeService
    {
        void Insert(PhieuKiemKe PhieuKiemKe, List<ChiTietKiemKe> dsPhieu, List<ChiTietKiemKeSanPham> ctPhieu);
        List<PhieuKiemKe> GetDanhSachPhieu();
        void SetDanhSachPhieu(List<PhieuKiemKe> danhSachPhieu);
        int GetAutoIncrement();
        List<PhieuKiemKe> SelectAll();
        void Cancel(int index);
        List<ChiTietKiemKe> GetChitietKiemKe(int maphieu);
        List<PhieuKiemKe> FilterPhieuKiemKe(int type, string input, int manv, DateTime timeStart, DateTime timeEnd);
    }
}
