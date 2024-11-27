using DAO.impl;
using DAO.Mapper.impl;
using Entity;
using MySql.Data.MySqlClient;
using State.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO.impl
{
    public class ChiTietSanPhamDAO : AbstractDAO<ChiTietSanPham>, IChiTietSanPham
    {
        private readonly ChiTietSanPhamRowMapper _rowMapper = new ChiTietSanPhamRowMapper();


        public bool checkImeiExists(List<long> imeis)
        {
            String query = "select * from ctsanpham where maimei in (";
            query += string.Join(", ", imeis.Select(_ => "?"));
            query += ")";
            List<ChiTietSanPham> result = this.Query(query, _rowMapper, imeis);
            return result.Count > 0;
        }

        public void delete(long id)
        {
            String query = "update ctsanpham set tinhtrang = 0 where maimei = ?";
            Update(query, id);
        }

        public ChiTietSanPham FindByMaImei(string maImei)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "maimei",
                Operation = ":",
                Value = maImei,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "ctsanpham").FirstOrDefault(null);
        }

        public List<ChiTietSanPham> FindByMaPhieuNhap(int maphieunhap)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "maphieunhap",
                Operation = ":",
                Value = maphieunhap,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "ctsanpham");
        }

        public List<ChiTietSanPham> FindByMaPhieuXuat(int maphieuxuat)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "maphieuxuat",
                Operation = ":",
                Value = maphieuxuat,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "ctsanpham");
        }

        public List<ChiTietSanPham> FindByPhienBanSanPham(int pbsp)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "maphienbansp",
                Operation = ":",
                Value = pbsp,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "ctsanpham");
        }

        public int insert(ChiTietSanPham t)
        {
            int result = 0;
            try
            {
                String connectionString = "Server=localhost;Database=quanlikhohang;User ID=root;Password=12345;Port=3306";
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "INSERT INTO ctsanpham (maimei, maphienbansp, maphieunhap, tinhtrang) VALUES (@param0, @param1, @param2, @param3)";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@param0", t.MaImei);
                        cmd.Parameters.AddWithValue("@param1", t.MaPhienBanSanPham);
                        cmd.Parameters.AddWithValue("@param2", t.MaPhieuNhap);
                        cmd.Parameters.AddWithValue("@param3", t.TinhTrang);

                        result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error during insert: " + ex.Message);
                            }
            return result; 
        }

        public bool insert_mutiple(List<ChiTietSanPham> list)
        {
            long result = 0;
           
            foreach (ChiTietSanPham sp in list)
            {
                result += this.insert(sp);
                Console.WriteLine("failed here"+ " "+ result);
            }
            bool success= result > 0;

            return success;
        }

        public void update(ChiTietSanPham chiTietSanPham)
        {
            string query = @"
                UPDATE ctsanpham
                SET 
                    maphienbansp = @param0,
                    maphieunhap = @param1,
                    maphieuxuat = @param2,
                    tinhtrang = @param3
                WHERE
                    maimei = @param4;";

            Update(query,
                chiTietSanPham.MaPhienBanSanPham,
                chiTietSanPham.MaPhieuNhap,
                chiTietSanPham.MaPhieuXuat ?? (object)DBNull.Value,
                chiTietSanPham.TinhTrang,
                chiTietSanPham.MaImei
           );
        }
    
        public List<ChiTietSanPham> SelectAllByPb(int mapbsp)
        {
            // Query to fetch products with specified 'maphienbansp' and 'tinhtrang = 1'
            string query = "SELECT * FROM ctsanpham WHERE maphienbansp = @param0 AND tinhtrang = 1";

            // Use the Query method to execute the SQL and map the results
            return this.Query(query, _rowMapper, mapbsp);
        }

        public void UpdateXuat(ChiTietSanPham chiTietSanPham)
        {
            string query = @"
        UPDATE ctsanpham
        SET 
            maphieuxuat = @param0,
            tinhtrang = @param1
        WHERE
            maimei = @param2;";

            Update(query,
                chiTietSanPham.MaPhieuXuat ?? (object)DBNull.Value, // Handle nullable value
                chiTietSanPham.TinhTrang,
                chiTietSanPham.MaImei
            );
        }




    }
}
