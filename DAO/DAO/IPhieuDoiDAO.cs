using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface IPhieuDoiDAO : IGenericDAO<PhieuDoi>
    {
        List<PhieuDoi> GetAll();

        long insert(PhieuDoi phieudoi);
        void update(PhieuDoi phieudoi);
        void delete(long id);
        List<PhieuDoi> FindLikeName(string name);
    }
}
