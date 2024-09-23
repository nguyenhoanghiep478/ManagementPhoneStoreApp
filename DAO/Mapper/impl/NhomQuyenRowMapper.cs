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
    public class NhomQuyenRowMapper : IRowMapper<NhomQuyen>
    {
        public NhomQuyen MapRow(IDataReader reader)
        {
            return new NhomQuyen
            {
                Manhomquyen = reader.GetInt32(reader.GetOrdinal("manhomquyen")),
                Tennhomquyen = reader.IsDBNull(reader.GetOrdinal("tennhomquyen")) ? null : reader.GetString(reader.GetOrdinal("tenhedieuhanh")),
                Trangthai = reader.GetInt32(reader.GetOrdinal("trangthai"))
            };
        }
    }
}
