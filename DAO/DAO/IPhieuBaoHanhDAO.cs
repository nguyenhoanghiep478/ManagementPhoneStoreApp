using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO.DAO
{
    public interface IPhieuBaoHanhDAO : IGenericDAO<PhieuBaoHanh>
    {
        List<PhieuBaoHanh> GetAll();

        long Insert(PhieuBaoHanh phieubaohanh);

        void Update(PhieuBaoHanh phieubaohanh);

        void Delete(long id);

        List<PhieuBaoHanh> FindLikeName(string name);
    }
}
