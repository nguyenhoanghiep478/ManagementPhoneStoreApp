using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;


namespace DAO.DAO
{
    public interface IPhieuXuatDAO : IGenericDAO<PhieuXuat>
    {
        List<PhieuXuat> GetAll();

        long Insert(PhieuXuat phieuxuat);

        void Update(PhieuXuat phieuxuat);

        void Delete(long id);

        List<PhieuXuat> FindLikeName(string name);
    }
}
