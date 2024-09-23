using DAO.impl;
using DAO.Mapper.impl;
using DAO.utils;
using Entity;
using State.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO.impl
{
    public class ChiTietKiemKeDAO : AbstractDAO<ChiTietKiemKe>, IChiTietKiemKeDAO
    {
        private readonly ChiTietKiemKeRowMapper _rowMapper;
        public void delete(long id)
        {
            String query = "update ctkiemke set trangthai = 0 where  = ?";
            Update(query, id);
        }

        public ChiTietKiemKe FindBy(int maphieukiemke)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "maphieukiemke",
                Operation = ":",
                Value = maphieukiemke,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "chitietsanpham").FirstOrDefault(null);
        }

        public long insert(ChiTietKiemKe chiTietKiemKe)
        {
            string query = @"
                INSERT INTO ChiTietKiemKe 
                (
                    maphieukiemke, masanpham, soluong, chenhlechte, ghichu
                ) 
                VALUES 
                (
                    @maphieukiemke, @masanpham, @soluong, @chenhlech, @ghichu
                );";

            return Save(query,
                chiTietKiemKe.MaPhieuKiemKe,
                chiTietKiemKe.MaSanPham,
                chiTietKiemKe.SoLuong,
                chiTietKiemKe.ChenhLech,
                chiTietKiemKe.GhiChu ?? (object)DBNull.Value
            );
        }

        public void update(ChiTietKiemKe chiTietKiemKe)
        {
            string query = @"
        UPDATE ChiTietKiemKe
        SET 
            masanpham = @masanpham,
            soluong = @soluong,
            chenhlechte = @chenhlech,
            ghichu = @ghichu
        WHERE 
            maphieukiemke = @maphieukiemke;";

           Update(query,
                chiTietKiemKe.MaSanPham,
                chiTietKiemKe.SoLuong,
                chiTietKiemKe.ChenhLech,
                chiTietKiemKe.GhiChu ?? (object)DBNull.Value, 
                chiTietKiemKe.MaPhieuKiemKe 
            );
        }
    }
}
