using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.impl;
using DAO.Mapper;
using DAO.Mapper.impl;
using Entity;
using State.Utils;


namespace DAO.DAO.impl
{
    public class PhieuTraDAO : AbstractDAO<PhieuTra>, IPhieuTraDAO
    {
        private readonly PhieuTraRowMapper _rowMapper = new PhieuTraRowMapper();

        public void Delete(long id)
        {
            string query = "UPDATE phieutra SET trangthai = @trangthai WHERE maphieutra = @maphieutra";
            Update(query, 0, id); // Assuming '0' represents a "deleted" status
            //need altering
        }

        public List<PhieuTra> FindLikeName(string name)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "maimei",
                Operation = "LIKE",
                Value = "%" + name + "%"
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "phieutra");
        }

        public List<PhieuTra> GetAll()
        {
            return SearchBy(null, _rowMapper, "phieutra");
        }

        public long Insert(PhieuTra phieutra)
        {
            string query = @"
                INSERT INTO phieutra
                (
                   maimei, lydo, thoigian, nguoitao
                ) 
                VALUES 
                (
                   @maimei, @lydo, @thoigian, @nguoitao
                );";
            return Save(query,
                phieutra.Maimei,
                phieutra.Lydo ?? (object)DBNull.Value,
                phieutra.Thoigian,
                phieutra.Nguoitao
            );
        }

        public void Update(PhieuTra phieutra)
        {
            string query = @"
                UPDATE phieutra 
                SET 
                    maimei = @maimei,
                    lydo = @lydo,
                    thoigian = @thoigian,
                    nguoitao = @nguoitao
                WHERE 
                    maphieutra = @maphieutra;";

            Update(query,
                phieutra.Maimei,
                phieutra.Lydo ?? (object)DBNull.Value,
                phieutra.Thoigian,
                phieutra.Nguoitao,
                phieutra.Maphieutra
            );
        }
    }
}
