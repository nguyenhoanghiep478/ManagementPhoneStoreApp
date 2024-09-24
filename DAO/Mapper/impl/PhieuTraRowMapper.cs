using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.utils;
using Entity;
using System.Data;

namespace DAO.Mapper.impl
{
    public class PhieuTraRowMapper : IRowMapper<PhieuTra>
    {
        public PhieuTra MapRow(IDataReader dataReader)
        {
            return new PhieuTra
            {
                Maphieutra = dataReader.IsDBNull(dataReader.GetOrdinal("maphieutra")) ? (int?)null : dataReader.GetInt32(dataReader.GetOrdinal("maphieutra")),
                Maimei = dataReader.IsDBNull(dataReader.GetOrdinal("maimei")) ? null : dataReader.GetString(dataReader.GetOrdinal("maimei")),
                Lydo = dataReader.IsDBNull(dataReader.GetOrdinal("lydo")) ? null : dataReader.GetString(dataReader.GetOrdinal("lydo")),
                Thoigian = dataReader.GetDateTime(dataReader.GetOrdinal("thoigian")),
                Nguoitao = dataReader.GetInt32(dataReader.GetOrdinal("nguoitao")) // Assuming this field is never null
            };
        }
    }
}
