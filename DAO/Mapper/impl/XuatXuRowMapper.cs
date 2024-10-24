
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
    public class XuatXuRowMapper : IRowMapper<XuatXu>
    {
        public XuatXu MapRow(IDataReader reader)
        {
            return new XuatXu
            {
                Maxuatxu = reader.GetInt32(reader.GetOrdinal("maxuatxu")),
                Tenxuatxu = reader.GetString(reader.GetOrdinal("tenxuatxu")),
                Trangthai = reader.GetBoolean(reader.GetOrdinal("trangthai"))
            };
        }
    }
}
