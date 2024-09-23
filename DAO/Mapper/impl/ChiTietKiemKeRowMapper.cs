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
    public class ChiTietKiemKeRowMapper : IRowMapper<ChiTietKiemKe>
    {
        public ChiTietKiemKe MapRow(IDataReader reader)
        {
            return new ChiTietKiemKe
            {
                MaPhieuKiemKe = reader.GetInt32(reader.GetOrdinal("maphieukiemmke")), 
                MaSanPham = reader.GetInt32(reader.GetOrdinal("masanpham")),
                SoLuong = reader.GetInt32(reader.GetOrdinal("soluong")),
                ChenhLech = reader.GetInt32(reader.GetOrdinal("chenhlech")),
                GhiChu = reader.IsDBNull(reader.GetOrdinal("ghichu")) ? null : reader.GetString(reader.GetOrdinal("ghichu"))
            };
        }
    }
}
