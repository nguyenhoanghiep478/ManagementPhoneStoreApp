using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    internal interface IMauSacDAO : IGenericDAO<MauSac>
    {
        List<MauSac> GetAll();

        long insert(MauSac mauSac);
        void update(MauSac mauSac);
        void delete(long id);
        List<MauSac> FindLikeName(string name);
    }
}
