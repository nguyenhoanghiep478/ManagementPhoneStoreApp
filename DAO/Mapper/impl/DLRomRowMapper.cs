
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
    public class DLRomRowMapper : IRowMapper<DLRom>
    {
        public DLRom MapRow(IDataReader reader)
        {
            return new DLRom
            {
                Madlrom = reader.GetInt32(reader.GetOrdinal("madlrom")),
                Kichthuocrom = reader.GetInt32(reader.GetOrdinal("kichthuocrom")),
                Trangthai = reader.GetBoolean(reader.GetOrdinal("trangthai"))
            };
        }
    }
}
