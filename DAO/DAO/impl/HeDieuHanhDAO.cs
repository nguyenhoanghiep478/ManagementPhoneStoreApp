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
    public class HeDieuHanhDAO :AbstractDAO<HeDieuHanh>,IHeDieuHanhDAO
    {
        private readonly HeDieuHanhRowMapper _rowMapper = new HeDieuHanhRowMapper();
        public void delete(long id)
        {
            String query = @"UPDATE hedieuhanh set trangthai=@trangthai";
            Update(query, id);
        }

        public List<HeDieuHanh> FindLikeName(string name)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "tenhedieuhanh",
                Operation = "LIKE",
                Value = name,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "hedieuhanh");
        }

        public List<HeDieuHanh> GetAll()
        {
            return SearchBy(null, _rowMapper, "hedieuhanh");
        }

        public long insert(HeDieuHanh hedieuhanh)
        {
            string query = @"
                INSERT INTO hedieuhanh
                (
                 mahedieuhanh,tenhedieuhanh,trangthai
                ) 
                VALUES 
                (
                    @mahedieuhanh,@tenhedieuhanh,@trangthai
                );";
            return Save(query,
                 hedieuhanh.Mahedieuhanh,
                 hedieuhanh.Tenhedieuhanh ?? (object)DBNull.Value,
                
                 hedieuhanh.Trangthai ?? (object)DBNull.Value

             );
        }

        public void update(HeDieuHanh hedieuhanh)
        {
            string query = @"
            UPDATE hedieuhanh
            SET 
                tenhedieuhanh = @tenhedieuhanh,
                trangthai = @trangthai
                WHERE 
                mahedieuhanh = @mahedieuhanh;";

            Update(query,
                hedieuhanh.Tenhedieuhanh ??(object)DBNull.Value,
                hedieuhanh.Trangthai ?? (object)DBNull.Value,
                hedieuhanh.Mahedieuhanh
            );
        }
    }
}
