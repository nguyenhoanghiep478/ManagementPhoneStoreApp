using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface IChiTietKiemKeDAO
    {
        long insert(ChiTietKiemKe chiTietKiemKe);
        void update(ChiTietKiemKe chiTietKiemKe);
        void delete(long id);
        ChiTietKiemKe  FindBy(int maphieukiemke);
    }
}
