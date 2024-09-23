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
    public class PhieuDoiDAO : AbstractDAO<PhieuDoi>, IPhieuDoiDAO
    {
        private readonly PhieuDoiRowMapper _rowMapper = new PhieuDoiRowMapper();
        public void delete(long id)
        {
            String query = "update from phieudoi set trangthai=@trangthai where maphieudoi=@maphieudoi";
            Update(query,0, id);
        }

        public List<PhieuDoi> FindLikeName(string name)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "maimei",
                Operation = "LIKE",
                Value = name,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "phieudoi");
        }

        public List<PhieuDoi> GetAll()
        {
            return SearchBy(null, _rowMapper, "phieudoi");
        }

        public long insert(PhieuDoi phieudoi)
        {
            string query = @"
                INSERT INTO phieudoi
                (
                   maphieudoi,maimei,lydo,thoigian,nguoitao
                ) 
                VALUES 
                (
                   @maphieudoi,@maimei,@lydo,@thoigian,@nguoitao
                );";
            return Save(query,
            phieudoi.Maphieudoi,
            phieudoi.Maimei,
            phieudoi.Lydo ?? (object)DBNull.Value,
            phieudoi.Thoigian,
            phieudoi.Nguoitao ?? (object)DBNull.Value
            );
        }

        public void update(PhieuDoi phieudoi)
        {
            string query = @"
            UPDATE phieudoi 
            SET 
                 maphieudoi=@maphieudoi,
                 maimei=@maimei,
                lydo=@lydo,
                thoigain=@thoigian,
                nguoitao=@nguoitao
                WHERE 
            maphieudoi = maphieudoi;";

            Update(query,
             phieudoi.Maphieudoi,
            phieudoi.Maimei,
            phieudoi.Lydo ?? (object)DBNull.Value,
            phieudoi.Thoigian,
            phieudoi.Nguoitao ?? (object)DBNull.Value
            );
        }
    }
}
