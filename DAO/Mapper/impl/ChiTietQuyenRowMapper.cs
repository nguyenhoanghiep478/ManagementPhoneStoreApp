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
    public class ChiTietQuyenRowMapper : IRowMapper<ChiTietQuyen>
    {
        public ChiTietQuyen MapRow(IDataReader reader)
        {
            return new ChiTietQuyen
            {
                MaNhomQuyen = reader.GetInt32(reader.GetOrdinal("manhomquyen")), 
                MaChucNang = reader.IsDBNull(reader.GetOrdinal("machucnang")) ? null : reader.GetString(reader.GetOrdinal("machucnang")),
                HanhDong = reader.IsDBNull(reader.GetOrdinal("hanhdong")) ? null : reader.GetString(reader.GetOrdinal("hanhdong"))
            };
        }
    }
}
