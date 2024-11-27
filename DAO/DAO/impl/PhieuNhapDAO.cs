using DAO.impl;
using DAO.Mapper;
using Entity;
using MySql.Data.MySqlClient;
using State.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

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
            string query = "SELECT * FROM ctsanpham WHERE maphieunhap = @param0";

            try
            {
                var result = Query(query, _rowMapper, maphieu);

                // Check if all ChiTietSanPham have MaPhieuXuat as 0
                return result.All(ct => ct.Maphieunhap == 0);
            }
            catch (Exception ex)
            {
                // Handle errors
                Console.WriteLine($"Error checking cancel: {ex.Message}");
                return false;
            }
        }

        public int CancelPhieuNhap(int maphieu)
        {
            int result = 0;

            // Delete details of the PhieuNhap from ChiTietSanPham and update the stock
            ctspDAO.delete(maphieu);

            // Fetch the list of details associated with the PhieuNhap
            var chiTietPhieuNhapList = ctpnDAO.SelectAll(maphieu.ToString());

            // Update the stock quantity based on the canceled PhieuNhap details
            foreach (var chiTietPhieuNhap in chiTietPhieuNhapList)
            {
                pbsp.UpdateSoLuongTon(chiTietPhieuNhap.Maphienbansp, -(chiTietPhieuNhap.Soluong));
            }

            // Delete the PhieuNhap record from the database
            string query = "DELETE FROM phieunhap WHERE maphieunhap = @param0";
            try
            {
                // Execute the update query (no result expected from the Update method)
                Update(query, maphieu);

                result = 1;  // Indicating success (you can adjust this based on your needs)
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during cancellation: {ex.Message}");
            }

            return result;
        }


    }

}
