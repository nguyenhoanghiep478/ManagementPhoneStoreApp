using DAO.impl;
using DAO.Mapper;
using DAO.Mapper.impl;
using DAO.utils;
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
    public class ChiTietPhieuXuatDAO : AbstractDAO<ChiTietPhieuXuat>, IChiTietPhieuXuatDAO
    {
        private readonly ChiTietPhieuXuatRowMapper _rowMapper = new ChiTietPhieuXuatRowMapper();
        private PhienBanSanPhamDAO pbsp=new PhienBanSanPhamDAO();
          public int insert(List<ChiTietPhieuXuat> list)
        {
            int result = 0;
            string query = @"
    INSERT INTO ctphieuxuat
    (
        maphieuxuat, maphienbansp, soluong, dongia
    ) 
    VALUES 
    (@param0, @param1, @param2, @param3);";

            //string ConnectionString = "Server=localhost;Database=quanlikhohang;User ID=root;Password=minhmankieu456;Port=3306";

            //using (var con = new MySqlConnection(ConnectionString))
            //{
            //    con.Open();

            //    using (var transaction = con.BeginTransaction())
            //    {
            //        try
            //        {
            //            using (var cmd = new MySqlCommand(query, con, transaction))
            //            {
            //                foreach (var item in list)
            //                {
            //                    cmd.Parameters.Clear();
            //                    cmd.Parameters.AddWithValue("@param0", item.Maphieuxuat);
            //                    cmd.Parameters.AddWithValue("@param1", item.Maphienbansp);
            //                    cmd.Parameters.AddWithValue("@param2", item.Soluong);
            //                    cmd.Parameters.AddWithValue("@param3", item.Dongia);

            //                    cmd.ExecuteNonQuery();

            //                    pbsp.UpdateSoLuongTon(item.Maphienbansp, -item.Soluong);
            //                }
            //            }

            //            transaction.Commit();
            //            result = list.Count; 
            //        }
            //        catch (Exception ex)
            //        {
            //            transaction.Rollback();
            //            Console.WriteLine($"Error: {ex.Message}");
            //        }
            //    }
            //}
            foreach (var item in list)
            {
                Save(query, item.Maphieuxuat, item.Maphienbansp, item.Soluong, item.Dongia);
                pbsp.UpdateSoLuongTon(item.Maphienbansp, -item.Soluong);
            }
            result = list.Count;
            return result;
        }


        // Update existing ChiTietPhieuXuat
        public void update(ChiTietPhieuXuat chiTietPhieuXuat)
        {
            string query = @"
                UPDATE ctphieuxuat 
                SET 
                    soluong = @param0,
                    dongia = @param1
                WHERE 
                    maphieuxuat = @param2 AND maphienbansp = @param3;";

            Update(query,
                chiTietPhieuXuat.Soluong,
                chiTietPhieuXuat.Dongia,
                chiTietPhieuXuat.Maphieuxuat,
                chiTietPhieuXuat.Maphienbansp
            );
        }

        // Delete by composite key (maphieuxuat and maphienbansp)
        public void delete(int maphieuxuat, int maphienbansp)
        {
            string query = "DELETE FROM ctphieuxuat WHERE maphieuxuat = @param0 AND maphienbansp = @param2;";
            Update(query, maphieuxuat, maphienbansp);
        }
        public List<ChiTietPhieuXuat> SelectAll(string maphieuxuat)
        {
            string query = "SELECT * FROM ctphieuxuat WHERE maphieuxuat = @param0";
            return Query(query, new ChiTietPhieuXuatRowMapper(), maphieuxuat);
        }
        public List<ChiTietPhieuXuat> GetByPhieuXuatId(int maphieuxuat)
        {
            List<Criteria> criterias = new List<Criteria>
            {
                new Criteria
                {
                    Key = "maphieuxuat",
                    Operation = ":",
                    Value = maphieuxuat
                }
            };

            return SearchBy(criterias, _rowMapper, "ctphieuxuat");
        }
        public List<ChiTietPhieuXuat> GetAll()
        {
            return SearchBy(null, _rowMapper, "ctphieuxuat");
        }
    }

}
