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
    public class NhanViewRowMapper : IRowMapper<NhanVien>
    {
        public NhanVien MapRow(IDataReader dataReader)
        {
            return new NhanVien {
                Manv = dataReader.GetInt32(dataReader.GetOrdinal("manv")),
                Hoten = dataReader.IsDBNull(dataReader.GetOrdinal("hoten")) ? null : dataReader.GetString(dataReader.GetOrdinal("hoten")),
                Giotinh = dataReader.IsDBNull(dataReader.GetOrdinal("giotinh")) ? (int?)null : dataReader.GetInt32(dataReader.GetOrdinal("giotinh")),
                Ngaysinh = dataReader.GetDateTime(dataReader.GetOrdinal("ngaysinh")), // Giả sử "ngaysinh" không bao giờ null
                Sdt = dataReader.IsDBNull(dataReader.GetOrdinal("sdt")) ? null : dataReader.GetString(dataReader.GetOrdinal("sdt")),
                Email = dataReader.IsDBNull(dataReader.GetOrdinal("email")) ? null : dataReader.GetString(dataReader.GetOrdinal("email")),
                Trangthai = dataReader.IsDBNull(dataReader.GetOrdinal("trangthai")) ? (int?)null : dataReader.GetInt32(dataReader.GetOrdinal("trangthai"))
            };
        }
    }

}
