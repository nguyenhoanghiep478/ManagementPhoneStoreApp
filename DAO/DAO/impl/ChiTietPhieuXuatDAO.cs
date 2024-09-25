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
                    @maphieuxuat, @maphienbansp, @soluong, @dongia
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
                    soluong = @soluong,
                    dongia = @dongia
                WHERE 
                    maphieuxuat = @maphieuxuat AND maphienbansp = @maphienbansp;";

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
            string query = "DELETE FROM ctphieuxuat WHERE maphieuxuat = @maphieuxuat AND maphienbansp = @maphienbansp;";
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
    }
}
