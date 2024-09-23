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
    public class HeDieuHanhRowMapper : IRowMapper<HeDieuHanh>
    {
        public HeDieuHanh MapRow(IDataReader reader)
        {
            return new HeDieuHanh
            {
                Mahedieuhanh = reader.GetInt32(reader.GetOrdinal("mahedieuhanh")),
                Tenhedieuhanh = reader.IsDBNull(reader.GetOrdinal("tenhedieuhanh")) ? null : reader.GetString(reader.GetOrdinal("tenhedieuhanh")),
                Trangthai = reader.GetInt32(reader.GetOrdinal("trangthai"))
            };

        }
    }
}
