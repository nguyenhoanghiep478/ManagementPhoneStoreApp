using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.impl;
using DAO.Mapper;
using DAO.Mapper.impl;
using Entity;
using MySql.Data.MySqlClient;
using State.Utils;


namespace DAO.DAO.impl
{
    public class PhieuXuatDAO : AbstractDAO<PhieuXuat>, IPhieuXuatDAO
    {
        private readonly PhieuXuatRowMapper _rowMapper = new PhieuXuatRowMapper();

        public void Delete(long id)
        {
            string query = "UPDATE phieuxuat SET trangthai = 0 WHERE maphieuxuat = @param0";
            Update(query, id);  // soft deletion
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
                  @param0, @param1, @param2, @param3, @param4, @param5
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
            
        public long insert(PhieuXuat phieuXuat)
        {
            string query = @"
                INSERT INTO phieuxuat 
                (
                    maphieuxuat, thoigian, makh, nguoitaophieuxuat, tongtien, trangthai
                ) 
                VALUES 
                (
                    @param0, @param1, @param2, @param3, @param4, @param5
                );";
            return Save(query,
                phieuXuat.Maphieuxuat,
               phieuXuat.Thoigian,
              phieuXuat.Makh,
              phieuXuat.Nguoitaophieuxuat,
               phieuXuat.Tongtien,
               phieuXuat.Trangthai
            );
        }

        public void Update(PhieuXuat phieuxuat)
        {
            string query = @"
                UPDATE phieuxuat 
                SET 
                    thoigian = @param0,
                    tongtien = @param1,
                    nguoitaophieuxuat = @param2,
                    makh = @param3,
                    trangthai = @param4
                WHERE 
                    maphieuxuat = @param5;";

            Update(query,
                phieuxuat.Thoigian,
                phieuxuat.Tongtien ?? (object)DBNull.Value,
                phieuxuat.Nguoitaophieuxuat ?? (object)DBNull.Value,
                phieuxuat.Makh ?? (object)DBNull.Value,
                phieuxuat.Trangthai ?? (object)DBNull.Value,
                phieuxuat.Maphieuxuat
            );
        }
        public int GetAutoIncrement()
        {
            int result = 0;

            string query = @"
    SELECT maphieuxuat 
    FROM phieuxuat
    ORDER BY maphieuxuat DESC LIMIT 1;";

            try
            {
                using (var connection = new MySqlConnection("Server=localhost;Database=quanlikhohang;User ID=root;Password=12345;Port=3306;"))
                {
                    connection.Open();

                    using (var command = new MySqlCommand(query, connection))
                    {
                        var scalarResult = command.ExecuteScalar();

                        if (scalarResult != DBNull.Value && scalarResult != null)
                        {
                            result = Convert.ToInt32(scalarResult);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            // Increment the result by 1 and return it
            return result + 1;
        }

    }
}
