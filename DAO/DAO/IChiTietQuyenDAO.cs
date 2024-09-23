using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface IChiTietQuyenDAO
    {
        long insert(ChiTietQuyen chiTietQuyen);
        void update(ChiTietQuyen chiTietQuyen);
        void delete(long id);
        ChiTietQuyen FindBy(int manhomquyen);
    }
}
