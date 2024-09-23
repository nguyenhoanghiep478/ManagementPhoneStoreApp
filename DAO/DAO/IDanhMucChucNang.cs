using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface IDanhMucChucNang
    {
        long insert(DanhMucChucNang sanPham);
        void update(DanhMucChucNang sanPham);
        void delete(long id);
        DanhMucChucNang FindByMaImei(string machucnang);
    }
}
