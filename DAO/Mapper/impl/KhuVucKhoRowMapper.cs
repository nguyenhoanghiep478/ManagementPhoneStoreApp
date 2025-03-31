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
    public class KhuVucKhoRowMapper : IRowMapper<KhuVucKho>
    {
        public KhuVucKho MapRow(IDataReader reader)
        {
            return new KhuVucKho
            {
                Makhuvuc = reader.GetInt32(reader.GetOrdinal("makhuvuc")),
                Tenkhuvuc = reader.IsDBNull(reader.GetOrdinal("tenkhuvuc")) ? null : reader.GetString(reader.GetOrdinal("tenkhuvuc")),
                Ghichu = reader.IsDBNull(reader.GetOrdinal("ghichu")) ? null : reader.GetString(reader.GetOrdinal("ghichu")),
                Trangthai = reader.GetInt32(reader.GetOrdinal("trangthai"))
            };
        }
    }
}
