using DAO.impl;
using DAO.Mapper;
using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DAO.DAO.impl
{
    public class ChiTietPhieuNhapDAO : AbstractDAO<ChiTietPhieuNhap>, IChiTietPhieuNhapDAO
    {
        private readonly ChiTietPhieuNhapRowMapper _rowMapper;
        private PhienBanSanPhamDAO pbsp = new PhienBanSanPhamDAO();

        public ChiTietPhieuNhapDAO()
        {
            _rowMapper = new ChiTietPhieuNhapRowMapper();
        }

        public void delete(long maphieunhap)
        {
            string query = "DELETE FROM ctphieunhap WHERE maphieunhap = ?";
            Update(query, maphieunhap);
        }

        public List<ChiTietPhieuNhap> GetAll()
        {
            return SearchBy(null, _rowMapper, "ctphieunhap");
        }

        // Insert a single ChiTietPhieuNhap
        public int insert(List<ChiTietPhieuNhap> list)
        {
            int result = 0;
            string query = @"
        INSERT INTO ctphieunhap
        (
            maphieunhap, maphienbansp, soluong, dongia, hinhthucnhap
        ) 
        VALUES 
        (@param0, @param1, @param2, @param3, @param4);";
            String ConnectionString =  "Server=localhost;Database=quanlikhohang;User ID=root;Password=12345;Port=3306";
            using (var con = new MySqlConnection(ConnectionString))
            {
                con.Open();

                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new MySqlCommand(query, con, transaction))
                        {
                            foreach (var item in list)
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@param0", item.Maphieunhap);
                                cmd.Parameters.AddWithValue("@param1", item.Maphienbansp);
                                cmd.Parameters.AddWithValue("@param2", item.Soluong);
                                cmd.Parameters.AddWithValue("@param3", item.Dongia);
                                cmd.Parameters.AddWithValue("@param4", item.Hinhthucnhap);

                                cmd.ExecuteNonQuery();

                                pbsp.UpdateSoLuongTon(item.Maphienbansp, item.Soluong);
                            }
                        }

                        transaction.Commit();
                        result = list.Count; 
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            return result; // Return the number of successfully inserted records
        }


    

        public void update(ChiTietPhieuNhap chiTietPhieuNhap)
        {
            string query = @"
            UPDATE ctphieunhap
            SET 
                soluong = @param0,
                dongia = @param1,
                hinhthucnhap = @param2
            WHERE 
                maphieunhap = @param3 AND maphienbansp = @param4;";

            Update(query,
                chiTietPhieuNhap.Soluong,
                chiTietPhieuNhap.Dongia,
                chiTietPhieuNhap.Hinhthucnhap,
                chiTietPhieuNhap.Maphieunhap,
                chiTietPhieuNhap.Maphienbansp
            );
        }

        public List<ChiTietPhieuNhap> SelectAll(string t)
        {
            List<ChiTietPhieuNhap> result = new List<ChiTietPhieuNhap>();
            try
            {
                String ConnectionString = "Server=localhost;Database=quanlikhohang;User ID=root;Password=12345;Port=3306";
                using (var con = new MySqlConnection(ConnectionString))
                {
                    con.Open();
                    string sql = "SELECT * FROM ctphieunhap WHERE maphieunhap = @maphieunhap";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        // Adding parameter to the SQL command
                        cmd.Parameters.AddWithValue("@maphieunhap", t);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int maphieu = reader.GetInt32("maphieunhap");
                                int maphienbansp = reader.GetInt32("maphienbansp");
                                int dongia = reader.GetInt32("dongia");
                                int soluong = reader.GetInt32("soluong");
                                int phuongthucnhap = reader.GetInt32("hinhthucnhap");

                                ChiTietPhieuNhap ctphieu = new ChiTietPhieuNhap(phuongthucnhap, maphieu, maphienbansp, soluong, dongia);
                                result.Add(ctphieu);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine(ex.Message);
            }

            return result;
        }

    }

}
