using DAO.utils;
using Entity;
using System;
using System.Data;

namespace DAO.Mapper
{
    public class PhieuNhapRowMapper : IRowMapper<PhieuNhap>
    {
        public PhieuNhap MapRow(IDataReader reader)
        {
            return new PhieuNhap
            {
                Maphieunhap = reader.GetInt32(reader.GetOrdinal("maphieunhap")),
                Thoigian = reader.GetDateTime(reader.GetOrdinal("thoigian")),
                Manhacungcap = reader.GetInt32(reader.GetOrdinal("manhacungcap")),
                Nguoitao = reader.IsDBNull(reader.GetOrdinal("nguoitao")) ? null : reader.GetInt32(reader.GetOrdinal("nguoitao")).ToString(),
                Tongtien = reader.GetInt64(reader.GetOrdinal("tongtien")),
                Trangthai = reader.GetInt32(reader.GetOrdinal("trangthai"))
            };
        }
    }
}
