using DAO.DAO;
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
    public class PhienBanSanPhamRowMapper : IRowMapper<PhienBanSanPham>
    {
        public virtual PhienBanSanPham MapRow(IDataReader reader)
        {
            return new PhienBanSanPham
            {
                MaPhienBanSanPham = reader.IsDBNull(reader.GetOrdinal("maphienbansp")) ? 0 : reader.GetInt32(reader.GetOrdinal("maphienbansp")),
                MaSanPham = reader.IsDBNull(reader.GetOrdinal("masp")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("masp")),
                Rom = reader.IsDBNull(reader.GetOrdinal("rom")) ? 0 : reader.GetInt32(reader.GetOrdinal("rom")),
                Ram = reader.IsDBNull(reader.GetOrdinal("ram")) ? 0 : reader.GetInt32(reader.GetOrdinal("ram")),
                MauSac = reader.IsDBNull(reader.GetOrdinal("mausac")) ? 0 : reader.GetInt32(reader.GetOrdinal("mausac")),
                GiaNhap = reader.IsDBNull(reader.GetOrdinal("gianhap")) ? 0: reader.GetInt32(reader.GetOrdinal("gianhap")),
                GiaXuat = reader.IsDBNull(reader.GetOrdinal("giaxuat")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("giaxuat")),
                SoLuongTon = reader.IsDBNull(reader.GetOrdinal("soluongton")) ? 0 : reader.GetInt32(reader.GetOrdinal("soluongton")),
                TrangThai = reader.IsDBNull(reader.GetOrdinal("trangthai")) ? true : reader.GetBoolean(reader.GetOrdinal("trangthai"))
            };

        }
    }
}
