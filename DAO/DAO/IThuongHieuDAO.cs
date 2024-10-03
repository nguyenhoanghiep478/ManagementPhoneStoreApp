using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface IThuongHieuDAO : IGenericDAO<ThuongHieu>
    {
        List<ThuongHieu> GetAll();

        long insert(ThuongHieu thuonghieu);
        void update(ThuongHieu thuonghieu);
        void delete(long id);
    }
}
