using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface ISanPhamDAO : IGenericDAO<SanPham>
    {
        List<SanPham> GetAll();

        long insert(SanPham sanPham);
        void update(SanPham sanPham);
        void delete(long id);
        List<SanPham> FindLikeName(string name);
        SanPham FindByMaPb(string pb);
    }
}
