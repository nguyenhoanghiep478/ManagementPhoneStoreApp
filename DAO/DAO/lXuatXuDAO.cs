using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    internal interface IXuatXuDAO : IGenericDAO<XuatXu>
    {
        List<XuatXu> GetAll();

        long insert(XuatXu xuatXu);
        void update(XuatXu xuatXu);
        void delete(long id);
        List<XuatXu> FindLikeName(string name);
    }
}
