using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    internal interface IDLRamDAO : IGenericDAO<DLRam>
    {
        List<DLRam> GetAll();

        long insert(DLRam dLRam);
        void update(DLRam dLRam);
        void delete(long id);
        List<DLRam> FindLikeName(string name);
    }
}
