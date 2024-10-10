using DAO.utils;
using Entity;
using System;
using System.Data;

namespace DAO.Mapper
{
    public class ChiTietPhieuNhapRowMapper : IRowMapper<ChiTietPhieuNhap>
    {
        public ChiTietPhieuNhap MapRow(IDataReader reader)
        {
            return new ChiTietPhieuNhap
            {
                Maphieunhap = reader.GetInt32(reader.GetOrdinal("maphieunhap")),
                Maphienbansp = reader.GetInt32(reader.GetOrdinal("maphienbansp")),
                Soluong = reader.GetInt32(reader.GetOrdinal("soluong")),
                Dongia = reader.GetInt32(reader.GetOrdinal("dongia")),
                Hinhthucnhap = reader.GetInt32(reader.GetOrdinal("hinhthucnhap"))
            };
        }
    }
}
