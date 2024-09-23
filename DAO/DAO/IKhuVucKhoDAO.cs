using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface IKhuVucKhoDAO :IGenericDAO<KhuVucKho>
    {
        List<KhuVucKho> GetAll();

        long insert(KhuVucKho khuvcukho);
        void update(KhuVucKho khuvuckho);
        void delete(long id);
        List<KhuVucKho> FindLikeName(string name);
    }
}
