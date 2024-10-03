using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface IChiTietPhieuNhapDAO : IGenericDAO<ChiTietPhieuNhap>
    {
        List<ChiTietPhieuNhap> GetAll();

        long insert(ChiTietPhieuNhap chiTietPhieuNhap);
        void update(ChiTietPhieuNhap chiTietPhieuNhap);
        void delete(long id);
    }
}