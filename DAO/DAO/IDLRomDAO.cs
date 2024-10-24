using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    internal interface IDLRomDAO : IGenericDAO<DLRom>
    {
        List<DLRom> GetAll();

        long insert(DLRom dLRom);
        void update(DLRom dLRom);
        void delete(long id);
        List<DLRom> FindLikeName(string name);
    }
}
