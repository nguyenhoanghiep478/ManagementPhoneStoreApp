using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface INhanVienDAO : IGenericDAO<NhanVien>
    {
        List<NhanVien> GetAll();

        long insert(NhanVien nhanvien);
        void update(NhanVien nhanvien);
        void delete(long id);
        List<NhanVien> FindLikeName(string name);
    }
}
