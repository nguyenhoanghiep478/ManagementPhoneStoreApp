using DAO.utils;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mapper.impl
{
    public class PhieuDoiRowMapper : IRowMapper<PhieuDoi>
    {

        public PhieuDoi MapRow(IDataReader dataReader)
        {
            return new PhieuDoi {
                Maphieudoi = dataReader.IsDBNull(dataReader.GetOrdinal("maphieudoi")) ? (int?)null : dataReader.GetInt32(dataReader.GetOrdinal("maphieudoi")),
                Maimei = dataReader.IsDBNull(dataReader.GetOrdinal("maimei")) ? null : dataReader.GetString(dataReader.GetOrdinal("maimei")),
                Lydo = dataReader.IsDBNull(dataReader.GetOrdinal("lydo")) ? null : dataReader.GetString(dataReader.GetOrdinal("lydo")),
                Thoigian = dataReader.GetDateTime(dataReader.GetOrdinal("thoigian")) // Giả sử "thoigian" không bao giờ null
            };
        }
    }
}
