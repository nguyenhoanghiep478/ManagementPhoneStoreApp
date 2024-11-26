using DAO.impl;
using DAO.Mapper;
using Entity;
using MySql.Data.MySqlClient;
using State.Utils;
using System;
using System.Collections.Generic;

namespace DAO.DAO.impl
{
    public class PhieuNhapDAO : AbstractDAO<PhieuNhap>, IPhieuNhapDAO
    {
        private readonly PhieuNhapRowMapper _rowMapper;
        ChiTietSanPhamDAO ctspDAO = new ChiTietSanPhamDAO();
        PhienBanSanPhamDAO pbsp=new PhienBanSanPhamDAO();
        ChiTietPhieuNhapDAO ctpnDAO=new ChiTietPhieuNhapDAO();
        public PhieuNhapDAO()
        {
            _rowMapper = new PhieuNhapRowMapper();
        }

        public void delete(long id)
        {
            string query = "UPDATE phieunhap SET trangthai = 0 WHERE maphieunhap = ?";
            Update(query, id);
        }

        public List<PhieuNhap> GetAll()
        {
            return SearchBy(null, _rowMapper, "phieunhap");
        }

        public long insert(PhieuNhap phieuNhap)
        {
            string query = @"
                INSERT INTO PhieuNhap 
                (
                    maphieunhap, thoigian, manhacungcap, nguoitao, tongtien, trangthai
                ) 
                VALUES 
                (
                    @param0, @param1, @param2, @param3, @param4, @param5
                );";
            return Save(query,
                phieuNhap.Maphieunhap,
                phieuNhap.Thoigian,
                phieuNhap.Manhacungcap,
                phieuNhap.Nguoitao,
                phieuNhap.Tongtien,
                phieuNhap.Trangthai
            );
        }

        public void update(PhieuNhap phieuNhap)
        {
            string query = @"
            UPDATE PhieuNhap 
            SET 
                thoigian = @param0,
                manhacungcap = @param1,
                nguoitao = @param2,
                tongtien = @param3,
                trangthai = @param4
            WHERE 
                maphieunhap = @param5;";

            Update(query,
                phieuNhap.Thoigian,
                phieuNhap.Manhacungcap,
                phieuNhap.Nguoitao,
                phieuNhap.Tongtien,
                phieuNhap.Trangthai,
                phieuNhap.Maphieunhap
            );
        }

        public List<PhieuNhap> FindLikeNguoiTao(string nguoitao)
        {
            var criterias = new List<Criteria>
            {
                new Criteria
                {
                    Key = "nguoitao",
                    Operation = "LIKE",
                    Value = nguoitao
                }
            };
            return SearchBy(criterias, _rowMapper, "phieunhap");
        }
        public int GetAutoIncrement()
        {
            int result = 0;

            string query = @"
    SELECT maphieunhap 
    FROM phieunhap 
    ORDER BY maphieunhap DESC LIMIT 1;";

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
        public bool CheckCancelPn(int maphieu)
        {
            List<ChiTietSanPham> result = new List<ChiTietSanPham>();
            string query = "SELECT * FROM ctsanpham WHERE maphieunhap = @maphieunhap";

            try
            {
                using (var connection = new MySqlConnection("Server=localhost;Database=quanlikhohang;User ID=root;Password=12345;Port=3306;"))
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@maphieunhap", maphieu);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string imei = reader.GetString("maimei");
                                int macauhinh = reader.GetInt32("maphienbansp");
                                int maphieunhap = reader.GetInt32("maphieunhap");
                                int maphieuxuat = reader.GetInt32("maphieuxuat");
                                int tinhtrang = reader.GetInt32("tinhtrang");
                                bool tt;
                                if (tinhtrang==0)
                                {
                                    tt= false;
                                }
                                else
                                {
                                    tt = true;
                                }

                                var ct = new ChiTietSanPham(imei, macauhinh, maphieunhap, maphieuxuat, tt);
                                result.Add(ct);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking cancel: {ex.Message}");
                return false;
            }

            foreach (var chiTietSanPhamDTO in result)
            {
                if (chiTietSanPhamDTO.MaPhieuXuat != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public int CancelPhieuNhap(int maphieu)
        {
            int result = 0;

            // Delete details of the PhieuNhap from ChiTietSanPham and update the stock
             ctspDAO.delete(maphieu);

            var chiTietPhieuNhapList = ctpnDAO.SelectAll(maphieu.ToString());
            foreach (var chiTietPhieuNhap in chiTietPhieuNhapList)
            {
                pbsp.UpdateSoLuongTon(chiTietPhieuNhap.Maphienbansp, -(chiTietPhieuNhap.Soluong));
            }

            // Delete the PhieuNhap record itself
            ctpnDAO.delete(maphieu);

            // Perform the delete query on the PhieuNhap table
            string query = "DELETE FROM phieunhap WHERE maphieunhap = @maphieunhap";
            try
            {
                using (var connection = new MySqlConnection("Server=localhost;Database=quanlikhohang;User ID=root;Password=12345;Port=3306;"))
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@maphieunhap", maphieu);
                        result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during cancellation: {ex.Message}");
            }

            return result;
        }

    }

}
