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
        private readonly ChiTietQuyenRowMapper _rowMapper = new ChiTietQuyenRowMapper();
        public void delete(ChiTietQuyen ctQuyen)
        {
            String query = "delete from ctquyen where manhomquyen = @param0 and machucnang = @param1 and hanhdong = @param2";
            Update(query, ctQuyen.MaNhomQuyen,ctQuyen.MaChucNang,ctQuyen.HanhDong);
        }
        
        public List<ChiTietQuyen> getAll()
        {
            return SearchBy(null, _rowMapper, "ctquyen");
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
            return SearchBy(criterias, _rowMapper, "ctquyen").FirstOrDefault(null);
        }

        public long insert(Entity.ChiTietQuyen chiTietQuyen)
        {
            string query = @"
        INSERT INTO ctquyen 
        (
            manhomquyen, machucnang, hanhdong
        ) 
        VALUES 
        (
            @param0, @param1, @param2
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
        UPDATE ctquyen
        SET 
            machucnang = @param0,
            hanhdong = @param1
        WHERE 
            manhomquyen = @param2;";

            Update(query,
               chiTietQuyen.MaChucNang ?? (object)DBNull.Value,
               chiTietQuyen.HanhDong ?? (object)DBNull.Value,
               chiTietQuyen.MaNhomQuyen
               );


        }

        public void delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
