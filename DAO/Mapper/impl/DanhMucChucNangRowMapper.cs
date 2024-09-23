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
    public class DanhMucChucNangMapper : IRowMapper<DanhMucChucNang>
    {
        public DanhMucChucNang MapRow(IDataReader reader)
        {
            return new DanhMucChucNang
            {
                MaChucNang = reader.IsDBNull(reader.GetOrdinal("machucnang")) ? null : reader.GetString(reader.GetOrdinal("machucnang")),
                TenChucNang = reader.IsDBNull(reader.GetOrdinal("tenchucnang")) ? null : reader.GetString(reader.GetOrdinal("tenchucnang")),
                TrangThai = reader.GetBoolean(reader.GetOrdinal("trangthai")) 
            };
        }
    }
}
