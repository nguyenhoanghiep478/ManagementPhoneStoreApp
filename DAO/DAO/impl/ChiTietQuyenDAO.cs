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
    public class ChiTietQuyenDAO : AbstractDAO<ChiTietQuyen>, IChiTietQuyenDAO
    {
        private readonly ChiTietQuyenRowMapper _rowMapper;
        public void delete(long id)
        {
            String query = "update ctquyen set trangthai = 0 where manhomquyen = ?";
            Update(query, id);
        }

        public ChiTietQuyen FindBy(int manhomquyen)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "manhomquyen",
                Operation = ":",
                Value = manhomquyen,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "chitietsanpham").FirstOrDefault(null);
        }

        public long insert(Entity.ChiTietQuyen chiTietQuyen)
        {
            string query = @"
        INSERT INTO ChiTietQuyen 
        (
            manhomquyen, machucnang, hanhdong
        ) 
        VALUES 
        (
            @manhomquyen, @machucnang, @hanhdong
        );";

            return Save(query,
                chiTietQuyen.MaNhomQuyen,
                chiTietQuyen.MaChucNang ?? (object)DBNull.Value, // Sử dụng DBNull.Value nếu MaChucNang là null
                chiTietQuyen.HanhDong ?? (object)DBNull.Value // Sử dụng DBNull.Value nếu HanhDong là null
            );
        }

        public void update(Entity.ChiTietQuyen chiTietQuyen)
        {
            string query = @"
        UPDATE ChiTietQuyen
        SET 
            machucnang = @machucnang,
            hanhdong = @hanhdong
        WHERE 
            manhomquyen = @manhomquyen;";

            Update(query,
               chiTietQuyen.MaChucNang ?? (object)DBNull.Value,
               chiTietQuyen.HanhDong ?? (object)DBNull.Value,
               chiTietQuyen.MaNhomQuyen
               );


        }
    }
}
