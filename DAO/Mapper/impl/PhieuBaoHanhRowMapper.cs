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
    public class PhieuBaoHanhRowMapper : IRowMapper<PhieuBaoHanh>
    {
        public PhieuBaoHanh MapRow(IDataReader dataReader)
        {
            return new PhieuBaoHanh
            {
                Maphieubaohanh = dataReader.IsDBNull(dataReader.GetOrdinal("maphieubaohanh")) ? (int?)null : dataReader.GetInt32(dataReader.GetOrdinal("maphieubaohanh")),

                Maimei = dataReader.IsDBNull(dataReader.GetOrdinal("maimei")) ? null : dataReader.GetString(dataReader.GetOrdinal("maimei")),

                Lydo = dataReader.IsDBNull(dataReader.GetOrdinal("lydo")) ? null : dataReader.GetString(dataReader.GetOrdinal("lydo")),

                Thoigian = dataReader.GetDateTime(dataReader.GetOrdinal("thoigian")), // Assuming "thoigian" is never null

                Thoigiantra = dataReader.IsDBNull(dataReader.GetOrdinal("thoigiantra")) ? (DateTime?)null : dataReader.GetDateTime(dataReader.GetOrdinal("thoigiantra"))
            };
        }
    }
}
