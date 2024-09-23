using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    internal interface IPhieuKiemKeDAO :IGenericDAO<PhieuKiemKe>
    {
        List<PhieuKiemKe> GetAll();

        long insert(PhieuKiemKe phieuKiemKe);
        void update(PhieuKiemKe phieuKiemKe);
        void delete(long id);
        List<PhieuKiemKe> FindLikeName(string name);
    }
}
