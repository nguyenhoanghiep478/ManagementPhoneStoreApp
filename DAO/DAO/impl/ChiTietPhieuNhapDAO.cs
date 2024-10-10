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
                    @maphieunhap, @maphienbansp, @soluong, @dongia, @hinhthucnhap
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
                soluong = @soluong,
                dongia = @dongia,
                hinhthucnhap = @hinhthucnhap
            WHERE 
                maphieunhap = @maphieunhap AND maphienbansp = @maphienbansp;";

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
