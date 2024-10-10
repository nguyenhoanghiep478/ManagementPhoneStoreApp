using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface IPhieuNhapDAO : IGenericDAO<PhieuNhap>
    {
        List<PhieuNhap> GetAll();

        long insert(PhieuNhap phieunhap);
        void update(PhieuNhap phieunhap);
        void delete(long id);
        List<PhieuNhap> FindLikeNguoiTao(string nguoitao);
    }
}
