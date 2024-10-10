
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
    public class DLRamRowMapper : IRowMapper<DLRam>
    {
        public DLRam MapRow(IDataReader reader)
        {
            return new DLRam
            {
                Madlram = reader.GetInt32(reader.GetOrdinal("madlram")),
                Kichthuocram = reader.GetInt32(reader.GetOrdinal("kichthuocram")),
                Trangthai = reader.GetBoolean(reader.GetOrdinal("trangthai"))
            };
        }
    }
}
