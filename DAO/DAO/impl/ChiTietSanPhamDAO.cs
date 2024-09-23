using DAO.impl;
using DAO.Mapper.impl;
using Entity;
using State.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO.impl
{
    public class ChiTietSanPhamDAO : AbstractDAO<ChiTietSanPham>, IChiTietSanPham
    {
        private readonly ChiTietSanPhamRowMapper _rowMapper;
        public void delete(long id)
        {
            String query = "update ctsanpham set trangthai = 0 where maimei = ?";
            Update(query, id);
        }

        public ChiTietSanPham FindByMaImei(string maImei)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "maimei",
                Operation = ":",
                Value = maImei,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "chitietsanpham").FirstOrDefault(null);
        }


        public long insert(ChiTietSanPham chiTietSanPham)
        {
            string query = @"
                INSERT INTO ChiTietSanPham 
                (
                    maimei, maphienbansp, maphieunhap, maphieuxuat, tinhtrang
                ) 
                VALUES 
                (
                    @maimei, @maphienbansp, @maphieunhap, @maphieuxuat, @tinhtrang
                );";

            return Save(query,
                 chiTietSanPham.MaImei, 
                 chiTietSanPham.MaPhienBanSanPham,
                 chiTietSanPham.MaPhieuNhap, 
                 chiTietSanPham.MaPhieuXuat ?? (object)DBNull.Value, 
                 chiTietSanPham.TinhTrang 
            );
        }

        public void update(ChiTietSanPham chiTietSanPham)
        {
            string query = @"
                UPDATE ChiTietSanPham 
                SET 
                    maphienbansp = @maphienbansp,
                    maphieunhap = @maphieunhap,
                    maphieuxuat = @maphieuxuat,
                    tinhtrang = @tinhtrang
                WHERE
                    maimei = @maimei;";

             Update(query,
                 chiTietSanPham.MaPhienBanSanPham, 
                 chiTietSanPham.MaPhieuNhap, 
                 chiTietSanPham.MaPhieuXuat ?? (object)DBNull.Value, 
                 chiTietSanPham.TinhTrang, 
                 chiTietSanPham.MaImei 
            );
        }
    }
}
