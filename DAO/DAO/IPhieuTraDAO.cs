using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity;


namespace DAO.DAO
{
    public interface IPhieuTraDAO : IGenericDAO<PhieuTra>
    {
        List<PhieuTra> GetAll();
        long Insert(PhieuTra phieutra);
        void Update(PhieuTra phieutra);
        void Delete(long id);
        List<PhieuTra> FindLikeName(string name);
    }
}
