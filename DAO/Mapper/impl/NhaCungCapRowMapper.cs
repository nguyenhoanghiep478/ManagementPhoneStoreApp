using DAO.utils;
using Entity;
using System;
using System.Data;

namespace DAO.Mapper
{
    public class NhaCungCapRowMapper : IRowMapper<NhaCungCap>
    {
        public NhaCungCap MapRow(IDataReader reader)
        {
            return new NhaCungCap
            {
                Manhacungcap = reader.GetInt32(reader.GetOrdinal("manhacungcap")),
                Tennhacungcap = reader.IsDBNull(reader.GetOrdinal("tennhacungcap")) ? null : reader.GetString(reader.GetOrdinal("tennhacungcap")),
                Diachi = reader.IsDBNull(reader.GetOrdinal("diachi")) ? null : reader.GetString(reader.GetOrdinal("diachi")),
                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email")),
                Sdt = reader.IsDBNull(reader.GetOrdinal("sdt")) ? null : reader.GetString(reader.GetOrdinal("sdt")),
                Trangthai = reader.GetInt32(reader.GetOrdinal("trangthai"))
            };
        }
    }
}
