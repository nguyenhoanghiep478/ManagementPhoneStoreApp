using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IPhieuXuatService
    {
        List<PhieuXuat> GetAll();
        PhieuXuat GetSelect(int index);
        void Cancel(int px);
        void Remove(int px);
        void Insert(PhieuXuat px, List<ChiTietPhieu> ct);
        List<ChiTietPhieu> SelectCTP(int maphieu);
        List<PhieuXuat> FilterPhieuXuat(int type, string input, int makh, int manv, DateTime time_s, DateTime time_e, string price_min, string price_max);
    }
}
