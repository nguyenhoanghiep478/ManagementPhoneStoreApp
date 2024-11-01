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

    internal class PhieuKiemKeDAO : AbstractDAO<PhieuKiemKe>, IPhieuKiemKeDAO
    {

        private readonly PhieuKiemKeRowMapper _rowMapper = new PhieuKiemKeRowMapper();
        public void delete(long id)
        {
            
        }

        public List<PhieuKiemKe> FindLikeName(string name)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "thoigian",
                Operation = "LIKE",
                Value = name,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "phieukiemke");
        }

        public List<PhieuKiemKe> GetAll()
        {
            return SearchBy(null, _rowMapper, "phieukiemke");
        }

        public long insert(PhieuKiemKe phieuKiemKe)
        {
            string query = @"
                INSERT INTO phieukiemke
                (
                 maphieu,thoigian,nguoitaophieukiemke
                ) 
                VALUES 
                (
                    @param0, @param1, @param2
                );";
            return Save(query,
                 phieuKiemKe.Maphieu,
                 phieuKiemKe.Thoigian ?? (object)DBNull.Value,
                 phieuKiemKe.Nguoitaophieukiemke 

             );
        }
        
        public void update(PhieuKiemKe phieuKiemKe)
        {
            string query = @"
            UPDATE phieukiemke
            SET 
               
                thoigian = @param1
                WHERE 
               maphieu = @param0;";

            Update(query,
                phieuKiemKe.Maphieu,
                phieuKiemKe.Thoigian ?? (object)DBNull.Value
             
            );
        }
    }
}
