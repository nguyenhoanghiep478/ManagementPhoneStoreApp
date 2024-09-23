using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
     public interface INhomQuyenDAO :IGenericDAO<NhomQuyen>
    {
        List<NhomQuyen> GetAll();

        long insert(NhomQuyen nhomquyen);
        void update(NhomQuyen nhomquyen);
        void delete(long id);
        List<NhomQuyen> FindLikeName(string name);
    }
}
