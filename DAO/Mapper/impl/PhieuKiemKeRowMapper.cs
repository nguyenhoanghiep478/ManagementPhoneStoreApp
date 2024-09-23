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
    public class PhieuKiemKeRowMapper : IRowMapper<PhieuKiemKe>
    {
        public PhieuKiemKe MapRow(IDataReader reader)
        {
            return new PhieuKiemKe
            {
                Maphieu = reader.GetInt32(reader.GetOrdinal("maphieu")),
                Thoigian = reader.GetDateTime(reader.GetOrdinal("thoigian")),
                Nguoitaophieukiemke = reader.GetInt32(reader.GetOrdinal("nguoitaophieukiemke"))
            };
        }
    }
}
