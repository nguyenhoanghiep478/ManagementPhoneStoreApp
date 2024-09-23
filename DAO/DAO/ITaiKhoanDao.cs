using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface ITaiKhoanDao : IGenericDAO<TaiKhoan>
    {
        List<TaiKhoan> GetAll();

        long insert(TaiKhoan taiKhoan);
        void update(TaiKhoan taiKhoan);
        void delete(long id);
        List<TaiKhoan> FindLikeMaNv(string manv);
    }
}
