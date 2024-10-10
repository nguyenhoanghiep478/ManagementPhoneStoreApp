using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface INhaCungCapDAO : IGenericDAO<NhaCungCap>
    {
        List<NhaCungCap> GetAll();

        long insert(NhaCungCap nhaCungCap);
        void update(NhaCungCap nhaCungCap);
        void delete(long id);
    }
}