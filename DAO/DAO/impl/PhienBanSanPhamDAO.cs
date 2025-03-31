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
    public class PhienBanSanPhamDAO : AbstractDAO<PhienBanSanPham>, IPhienBanSanPham
    {
        private readonly PhienBanSanPhamRowMapper _rowMapper = new PhienBanSanPhamRowMapper();
        private SanPhamDAO spDAO=new SanPhamDAO();


        public void delete(long id)
        {
            String query = "update phienbansanpham set trangthai = 0 where maphienbansp = ?";
            Update(query, id);
        }

        public PhienBanSanPham FindByMaPhienBanSanPham(int maphienban)
        {
            if (maphienban <= 0)
            {
                throw new ArgumentException("Invalid maphienban value. It must be greater than 0.");
            }

            // Create criteria for the SQL query (checking by "maphienbansp")
            var criterias = new List<Criteria>
    {
        new Criteria
        {
            Key = "maphienbansp",  // Correct field name in the database
            Operation = ":",
            Value = maphienban
        }
    };

            // Search for matching records using the criteria
            var result = SearchBy(criterias, _rowMapper, "phienbansanpham");

            // If result is null or empty, return null or handle the case
            return result?.FirstOrDefault();
        }



        public List<PhienBanSanPham> FindByMaSp(string masp)
        {
            String sql = "SELECT * FROM phienbansanpham WHERE masp = ? and trangthai = 1";
            return this.Query(sql, _rowMapper, masp);
        }

        public long insert(PhienBanSanPham phienBanSanPham)
        {
            string query = @"
            INSERT INTO phienbansanpham 
            (
                maphienbansp, masp, rom, ram, mausac, gianhap, giaxuat, soluongton, trangthai
            ) 
            VALUES 
            (
              @param0, @param1, @param2, @param3, @param4, @param5,@param6,@param7,@param8
            );";

            return Save(query,
                phienBanSanPham.MaPhienBanSanPham,
                phienBanSanPham.MaSanPham ?? (object)DBNull.Value,
                phienBanSanPham.Rom,
                phienBanSanPham.Ram ?? (object)DBNull.Value,
                phienBanSanPham.MauSac,
                phienBanSanPham.GiaNhap ?? (object)DBNull.Value,
                phienBanSanPham.GiaXuat ?? (object)DBNull.Value,
                phienBanSanPham.SoLuongTon,
                phienBanSanPham.TrangThai ? 1 : 0
            );
        }

        public void update(PhienBanSanPham phienBanSanPham)
        {
            string query = @"
                UPDATE phienbansanpham
                SET 
                    masp = @param0,
                    rom = @param2,
                    ram = @param3,
                    mausac = @param4,
                    gianhap = @param5,
                    giaxuat = @param6,
                    soluongton = @param7,
                    trangthai = @param8
                WHERE 
                    maphienbansp = @param9;";

            Update(query,
               phienBanSanPham.MaSanPham ?? (object)DBNull.Value,
               phienBanSanPham.Rom,
               phienBanSanPham.Ram ?? (object)DBNull.Value,
               phienBanSanPham.MauSac,
               phienBanSanPham.GiaNhap ?? (object)DBNull.Value,
               phienBanSanPham.GiaXuat ?? (object)DBNull.Value,
               phienBanSanPham.SoLuongTon,
               phienBanSanPham.TrangThai ? 1 : 0,
               phienBanSanPham.MaPhienBanSanPham
           );
        }
        public void UpdateSoLuongTon(int maphienbansp, int soluong)
        {
            var phienBanSanPham = FindByMaPhienBanSanPham(maphienbansp);

            if (phienBanSanPham != null)
            {
                int newSoLuongTon = phienBanSanPham.SoLuongTon + soluong;
                string query = "UPDATE phienbansanpham SET soluongton = @param0 WHERE maphienbansp = @param1;";

                try
                {
                    Update(query, newSoLuongTon, maphienbansp);
                    spDAO.updateSoLuongTon((long)phienBanSanPham.MaSanPham, soluong);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in UpdateSoLuongTon: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Product version not found with maphienbansp: " + maphienbansp);
            }
        }

    }
}
