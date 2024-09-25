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
    public class PhieuXuatDAO : AbstractDAO<PhieuXuat>, IPhieuXuatDAO
    {
        private readonly PhieuXuatRowMapper _rowMapper = new PhieuXuatRowMapper();

        public void Delete(long id)
        {
            string query = "UPDATE phieuxuat SET trangthai = @trangthai WHERE maphieuxuat = @maphieuxuat";
            Update(query, 0, id);  // soft deletion
        }

        public List<PhieuXuat> FindLikeName(string name)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "makh",
                Operation = "LIKE",
                Value = "%" + name + "%" // LIKE with wildcards for partial matching
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "phieuxuat");
        }

        public List<PhieuXuat> GetAll()
        {
            return SearchBy(null, _rowMapper, "phieuxuat");
        }

        public long Insert(PhieuXuat phieuxuat)
        {
            string query = @"
                INSERT INTO phieuxuat
                (
                   maphieuxuat, thoigian, tongtien, nguoitaophieuxuat, makh, trangthai
                ) 
                VALUES 
                (
                   @maphieuxuat, @thoigian, @tongtien, @nguoitaophieuxuat, @makh, @trangthai
                );";
            return Save(query,
                phieuxuat.Maphieuxuat,
                phieuxuat.Thoigian,
                phieuxuat.Tongtien ?? (object)DBNull.Value,
                phieuxuat.Nguoitaophieuxuat ?? (object)DBNull.Value,
                phieuxuat.Makh ?? (object)DBNull.Value,
                phieuxuat.Trangthai ?? (object)DBNull.Value
            );
        }

        public void Update(PhieuXuat phieuxuat)
        {
            string query = @"
                UPDATE phieuxuat 
                SET 
                    thoigian = @thoigian,
                    tongtien = @tongtien,
                    nguoitaophieuxuat = @nguoitaophieuxuat,
                    makh = @makh,
                    trangthai = @trangthai
                WHERE 
                    maphieuxuat = @maphieuxuat;";

            Update(query,
                phieuxuat.Thoigian,
                phieuxuat.Tongtien ?? (object)DBNull.Value,
                phieuxuat.Nguoitaophieuxuat ?? (object)DBNull.Value,
                phieuxuat.Makh ?? (object)DBNull.Value,
                phieuxuat.Trangthai ?? (object)DBNull.Value,
                phieuxuat.Maphieuxuat
            );
        }
    }
}
