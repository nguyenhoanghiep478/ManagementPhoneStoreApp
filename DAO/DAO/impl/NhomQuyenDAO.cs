using DAO.impl;
using DAO.Mapper;
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
    public class NhomQuyenDAO : AbstractDAO<NhomQuyen>, INhomQuyenDAO
    {
        private readonly NhomQuyenRowMapper _rowMapper;
        public void delete(long id)
        {
            String query = "update  nhomquyen set trangthai=@trangthai where manhomquyen=@manhomquyen ";
            Update(query, id);
        }

        public List<NhomQuyen> FindLikeName(string name)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "tennhomquyen",
                Operation = "LIKE",
                Value = name,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "nhomquyen");
        }

        public List<NhomQuyen> GetAll()
        {
            return SearchBy(null, _rowMapper, "nhomquyen");
        }

        public long insert(NhomQuyen nhomquuyen)
        {
            string query = @"
                INSERT INTO nhomquyen
                (
                    manhomquyen, tennhomquyen, trangthai
                ) 
                VALUES 
                (
                    @manhomquyen, @tennhomquyen, @trangthai
                );";
            return Save(query,
                 nhomquuyen.Manhomquyen,
                 nhomquuyen.Tennhomquyen,
                 nhomquuyen.Trangthai
             );
        }

        public void update(NhomQuyen nhomquyen)
        {
            string query = @"
            UPDATE nhomquyen
            SET 
                tennhomquyen = @tennhomquyen,
                trangthai = @trangthai
                WHERE 
            masp = @masp;";

            Update(query,
                nhomquyen.Tennhomquyen,
                nhomquyen.Trangthai,
                nhomquyen.Manhomquyen
            );
        }
    }
}
