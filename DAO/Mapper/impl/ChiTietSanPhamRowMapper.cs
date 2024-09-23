using DAO.utils;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mapper.impl
{
    internal class ChiTietSanPhamRowMapper : IRowMapper<ChiTietSanPham>
    {
        public ChiTietSanPham MapRow(IDataReader reader)
        {
            return new ChiTietSanPham
            {
                MaImei = reader.IsDBNull(reader.GetOrdinal("maimei")) ? null : reader.GetString(reader.GetOrdinal("maimei")),
                MaPhienBanSanPham = reader.IsDBNull(reader.GetOrdinal("maphienbansp")) ? 0 : reader.GetInt32(reader.GetOrdinal("maphienbansp")),
                MaPhieuNhap = reader.IsDBNull(reader.GetOrdinal("maphieunhap")) ? 0 : reader.GetInt32(reader.GetOrdinal("maphieunhap")),
                MaPhieuXuat = reader.IsDBNull(reader.GetOrdinal("maphieuxuat")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("maphieuxuat")),
                TinhTrang = reader.IsDBNull(reader.GetOrdinal("tinhtrang")) ? false : reader.GetBoolean(reader.GetOrdinal("tinhtrang"))
            };
        }
    }
}
