using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface IHeDieuHanhDAO :IGenericDAO<HeDieuHanh>
    {
        List<HeDieuHanh> GetAll();

        long insert(HeDieuHanh hedieuhanh);
        void update(HeDieuHanh hedieuhanh);
        void delete(long id);
        List<HeDieuHanh> FindLikeName(string name);
    }
}
