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
        private ChiTietSanPhamDAO ctspDAO=new ChiTietSanPhamDAO();
        private ChiTietPhieuXuatDAO ctpxDAO=new ChiTietPhieuXuatDAO();
        private PhienBanSanPhamDAO pbspDAO = new PhienBanSanPhamDAO();
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
        public List<PhieuXuat> GetAllActive()
        {
            return this.GetAll().Where(px => px.Trangthai == 1).ToList();
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
            string query = @"
        SELECT COALESCE(MAX(maphieuxuat), 0) 
        FROM phieuxuat";

            return QueryScalar<int>(query) + 1;
        }

      

        public int CancelPhieuXuat(int maphieu)
        {
            int result = 0;

            ctspDAO.delete(maphieu);

            var chiTietPhieuXuatList = ctpxDAO.SelectAll(maphieu.ToString());

            // Update the stock quantity based on the canceled PhieuNhap details
            foreach (var chiTietPhieuNhap in chiTietPhieuXuatList)
            {
                pbspDAO.UpdateSoLuongTon(chiTietPhieuNhap.Maphienbansp, +(chiTietPhieuNhap.Soluong));
            }

            // Delete the PhieuNhap record from the database
            string query = "DELETE FROM phieuxuat WHERE maphieuxuat = @param0";
            try
            {
                // Execute the update query (no result expected from the Update method)
                this.Delete(maphieu);

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
