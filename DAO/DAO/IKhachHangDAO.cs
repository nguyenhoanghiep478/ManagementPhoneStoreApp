using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface IKhachHangDAO : IGenericDAO<KhachHang>
    {
        List<KhachHang> GetAll();
        long insert(KhachHang khachhang);
        void update(KhachHang khachhang);
        void delete(long id);
        List<KhachHang> FindLikeName(string name);
    }
}
