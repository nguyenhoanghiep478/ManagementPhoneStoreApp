
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
    public class MauSacRowMapper : IRowMapper<MauSac>
    {
        public MauSac MapRow(IDataReader reader)
        {
            return new MauSac
            {
                Mamau = reader.GetInt32(reader.GetOrdinal("mamau")),
                Tenmau = reader.GetString(reader.GetOrdinal("tenmau")),
                Trangthai = reader.GetBoolean(reader.GetOrdinal("trangthai"))
            };
        }
    }
}
