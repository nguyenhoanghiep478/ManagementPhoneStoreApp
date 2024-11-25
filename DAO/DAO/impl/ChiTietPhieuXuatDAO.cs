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
    public class ChiTietPhieuXuatDAO : AbstractDAO<ChiTietPhieuXuat>, IChiTietPhieuXuatDAO
    {
        private readonly ChiTietPhieuXuatRowMapper _rowMapper = new ChiTietPhieuXuatRowMapper();

        // Insert new ChiTietPhieuXuat
        public long insert(ChiTietPhieuXuat chiTietPhieuXuat)
        {
            string query = @"
                INSERT INTO ctphieuxuat
                (
                    maphieuxuat, maphienbansp, soluong, dongia
                ) 
                VALUES 
                (
                    @param0, @param1, @param2, @param3
                );";

            return Save(query,
                chiTietPhieuXuat.Maphieuxuat,
                chiTietPhieuXuat.Maphienbansp,
                chiTietPhieuXuat.Soluong,
                chiTietPhieuXuat.Dongia
            );
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

        // Find by maphieuxuat
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
