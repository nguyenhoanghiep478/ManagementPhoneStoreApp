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
    public class DanhMucChucNangDAO : AbstractDAO<DanhMucChucNang>, IDanhMucChucNang
    {
        private readonly DanhMucChucNangRowMapper _rowMapper = new DanhMucChucNangRowMapper();
        public void delete(long id)
        {
            String query = "update danhmucchucnang set trangthai = 0 where machucnang = ?";
            Update(query, id);
        }

        public DanhMucChucNang FindByMaImei(string machucnang)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "machucnang",
                Operation = ":",
                Value = machucnang,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "chitietsanpham").FirstOrDefault(null);
        }

        public long insert(DanhMucChucNang chucNang)
        {
                string query = @"
                    INSERT INTO ChucNang 
                    (
                        machucnang, tenchucnang, trangthai
                    ) 
                    VALUES 
                    (
                        @machucnang, @tenchucnang, @trangthai
                     );";

            return Save(query,
                chucNang.MaChucNang ?? (object)DBNull.Value, // Sử dụng DBNull.Value nếu MaChucNang là null
                chucNang.TenChucNang ?? (object)DBNull.Value, // Sử dụng DBNull.Value nếu TenChucNang là null
                chucNang.TrangThai ? 1 : 0 // Chuyển đổi bool sang tinyint
            );
        }

        public void update(DanhMucChucNang chucNang)
        {
            string query = @"
                UPDATE ChucNang
                SET 
                    tenchucnang = @tenchucnang,
                    trangthai = @trangthai
                WHERE 
                    machucnang = @machucnang;";

           Update(query,
                chucNang.TenChucNang ?? (object)DBNull.Value, 
                chucNang.TrangThai ? 1 : 0, 
                chucNang.MaChucNang 
            );
        }
    }
}
