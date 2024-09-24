using DAO.impl;
using DAO.Mapper;
using DAO.Mapper.impl;
using Entity;
using State.Utils;
using System;
using System.Collections.Generic;

namespace DAO.DAO.impl
{
    public class PhieuBaoHanhDAO : AbstractDAO<PhieuBaoHanh>, IPhieuBaoHanhDAO
    {
        private readonly PhieuBaoHanhRowMapper _rowMapper = new PhieuBaoHanhRowMapper();

        public void Delete(long id)
        {
            string query = "UPDATE phieubaohanh SET trangthai = @trangthai WHERE maphieubaohanh = @maphieubaohanh";
            Update(query, 0, id);  // Assuming `0` represents a "deleted" status
        }

        public List<PhieuBaoHanh> FindLikeName(string name)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "maimei",
                Operation = "LIKE",
                Value = "%" + name + "%" // LIKE with wildcards for partial matching
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "phieubaohanh");
        }

        public List<PhieuBaoHanh> GetAll()
        {
            return SearchBy(null, _rowMapper, "phieubaohanh");
        }

        public long Insert(PhieuBaoHanh phieubaohanh)
        {
            string query = @"
                INSERT INTO phieubaohanh
                (
                   maphieubaohanh, maimei, lydo, thoigian, thoigiantra
                ) 
                VALUES 
                (
                   @maphieubaohanh, @maimei, @lydo, @thoigian, @thoigiantra
                );";
            return Save(query,
                phieubaohanh.Maphieubaohanh,
                phieubaohanh.Maimei,
                phieubaohanh.Lydo ?? (object)DBNull.Value,
                phieubaohanh.Thoigian,
                phieubaohanh.Thoigiantra ?? (object)DBNull.Value
            );
        }

        public void Update(PhieuBaoHanh phieubaohanh)
        {
            string query = @"
                UPDATE phieubaohanh 
                SET 
                    maimei = @maimei,
                    lydo = @lydo,
                    thoigian = @thoigian,
                    thoigiantra = @thoigiantra
                WHERE 
                    maphieubaohanh = @maphieubaohanh;";

            Update(query,
                phieubaohanh.Maimei,
                phieubaohanh.Lydo ?? (object)DBNull.Value,
                phieubaohanh.Thoigian,
                phieubaohanh.Thoigiantra ?? (object)DBNull.Value,
                phieubaohanh.Maphieubaohanh
            );
        }
    }
}
