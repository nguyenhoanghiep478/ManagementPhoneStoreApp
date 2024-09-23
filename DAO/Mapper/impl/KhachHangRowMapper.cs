using DAO.utils;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mapper.impl
{
    internal class KhachHangRowMapper : IRowMapper<KhachHang>
    {
        public KhachHang MapRow(IDataReader reader)
        {
            return new KhachHang
            {
                MakH = reader.IsDBNull(reader.GetOrdinal("makh")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("makh")),
                TenKhachHang = reader.IsDBNull(reader.GetOrdinal("tenkhachhang")) ? null : reader.GetString(reader.GetOrdinal("tenkhachhang")),
                DiaChi = reader.IsDBNull(reader.GetOrdinal("diachi")) ? null : reader.GetString(reader.GetOrdinal("diachi")),
                Sdt = reader.IsDBNull(reader.GetOrdinal("sdt")) ? null : reader.GetString(reader.GetOrdinal("sdt")),
                TrangThai = reader.IsDBNull(reader.GetOrdinal("trangthai")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("trangthai")),
                NgayThamGia = reader.GetDateTime(reader.GetOrdinal("ngaythamgia")) 
            };
        }
    }
}
