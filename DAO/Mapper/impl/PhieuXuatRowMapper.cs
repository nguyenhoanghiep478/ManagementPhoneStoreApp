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
    public class PhieuXuatRowMapper : IRowMapper<PhieuXuat>
    {
        public PhieuXuat MapRow(IDataReader dataReader)
        {
            return new PhieuXuat
            {
                Maphieuxuat = dataReader.IsDBNull(dataReader.GetOrdinal("maphieuxuat")) ? (int?)null : dataReader.GetInt32(dataReader.GetOrdinal("maphieuxuat")),
                Thoigian = dataReader.GetDateTime(dataReader.GetOrdinal("thoigian")),
                Tongtien = dataReader.IsDBNull(dataReader.GetOrdinal("tongtien")) ? (long?)null : dataReader.GetInt64(dataReader.GetOrdinal("tongtien")),
                Nguoitaophieuxuat = dataReader.IsDBNull(dataReader.GetOrdinal("nguoitaophieuxuat")) ? (int?)null : dataReader.GetInt32(dataReader.GetOrdinal("nguoitaophieuxuat")),
                Makh = dataReader.IsDBNull(dataReader.GetOrdinal("makh")) ? (int?)null : dataReader.GetInt32(dataReader.GetOrdinal("makh")),
                Trangthai = dataReader.IsDBNull(dataReader.GetOrdinal("trangthai")) ? (int?)null : dataReader.GetInt32(dataReader.GetOrdinal("trangthai"))
            };
        }
    }
}
