
using DAO.utils;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mapper
{
    public class SanPhamRowMapper : IRowMapper<SanPham>
    {
        public SanPham MapRow(IDataReader reader)
        {
            return new SanPham
            {
                Masp = reader.GetInt32(reader.GetOrdinal("masp")),
                Tensp = reader.IsDBNull(reader.GetOrdinal("tensp")) ? null : reader.GetString(reader.GetOrdinal("tensp")),
                Hinhanh = reader.IsDBNull(reader.GetOrdinal("hinhanh")) ? null : reader.GetString(reader.GetOrdinal("hinhanh")),
                Xuatxu = reader.IsDBNull(reader.GetOrdinal("xuatxu")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("xuatxu")),
                Chipxuly = reader.IsDBNull(reader.GetOrdinal("chipxuly")) ? null : reader.GetString(reader.GetOrdinal("chipxuly")),
                Dungluongpin = reader.IsDBNull(reader.GetOrdinal("dungluongpin")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("dungluongpin")),
                Kichthuocman = reader.IsDBNull(reader.GetOrdinal("kichthuocman")) ? (double?)null : reader.GetDouble(reader.GetOrdinal("kichthuocman")),
                Hedieuhanh = reader.IsDBNull(reader.GetOrdinal("hedieuhanh")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("hedieuhanh")),
                Phienbanhdh = reader.IsDBNull(reader.GetOrdinal("phienbanhdh")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("phienbanhdh")),
                Camerasau = reader.IsDBNull(reader.GetOrdinal("camerasau")) ? null : reader.GetString(reader.GetOrdinal("camerasau")),
                Cameratruoc = reader.IsDBNull(reader.GetOrdinal("cameratruoc")) ? null : reader.GetString(reader.GetOrdinal("cameratruoc")),
                Thoigianbaohanh = reader.IsDBNull(reader.GetOrdinal("thoigianbaohanh")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("thoigianbaohanh")),
                Thuonghieu = reader.IsDBNull(reader.GetOrdinal("thuonghieu")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("thuonghieu")),
                Khuvuckho = reader.IsDBNull(reader.GetOrdinal("khuvuckho")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("khuvuckho")),
                Soluongton = reader.GetInt32(reader.GetOrdinal("soluongton")),
                Trangthai = reader.GetBoolean(reader.GetOrdinal("trangthai"))
            };
        }
    }
}
