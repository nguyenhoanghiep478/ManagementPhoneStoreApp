using DAO.utils;
using Entity;
using System;
using System.Data;

namespace DAO.Mapper
{
    public class ThuongHieuRowMapper : IRowMapper<ThuongHieu>
    {
        public ThuongHieu MapRow(IDataReader reader)
        {
            return new ThuongHieu
            {
                Mathuonghieu = reader.GetInt32(reader.GetOrdinal("mathuonghieu")),
                Tenthuonghieu = reader.IsDBNull(reader.GetOrdinal("tenthuonghieu")) ? null : reader.GetString(reader.GetOrdinal("tenthuonghieu")),
                Trangthai = reader.GetInt32(reader.GetOrdinal("trangthai"))
            };
        }
    }
}