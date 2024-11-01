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
        private readonly NhomQuyenRowMapper _rowMapper = new NhomQuyenRowMapper();
        public void delete(long id)
        {
            String query = "update  nhomquyen set trangthai=@param0 where manhomquyen=@param1 ";
            Update(query,0,id);
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
                    @param0, @param1, @param2
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
                tennhomquyen = @param0,
                trangthai = @param1
                WHERE 
            masp = @param2;";

            Update(query,
                nhomquyen.Tennhomquyen,
                nhomquyen.Trangthai,
                nhomquyen.Manhomquyen
            );
        }
    }
}
