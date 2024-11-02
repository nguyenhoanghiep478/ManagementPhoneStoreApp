using DAO.impl;
using DAO.Mapper;
using Entity;
using System;
using System.Collections.Generic;

namespace DAO.DAO.impl
{
    public class ChiTietPhieuNhapDAO : AbstractDAO<ChiTietPhieuNhap>, IChiTietPhieuNhapDAO
    {
        private readonly ChiTietPhieuNhapRowMapper _rowMapper;

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

        public long insert(ChiTietPhieuNhap chiTietPhieuNhap)
        {
            string query = @"
                INSERT INTO ctphieunhap
                (
                    maphieunhap, maphienbansp, soluong, dongia, hinhthucnhap
                ) 
                VALUES 
                (
                   @param0, @param1, @param2, @param3, @param4
                );";
            return Save(query,
                chiTietPhieuNhap.Maphieunhap,
                chiTietPhieuNhap.Maphienbansp,
                chiTietPhieuNhap.Soluong,
                chiTietPhieuNhap.Dongia,
                chiTietPhieuNhap.Hinhthucnhap
            );
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
    }
}
