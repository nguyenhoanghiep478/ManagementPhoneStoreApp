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
    public class TaiKhoanRowMapper : IRowMapper<TaiKhoan>
    {
        public TaiKhoan MapRow(IDataReader dataReader)
        {
            return new TaiKhoan
            {
                Manv =dataReader.GetInt32(dataReader.GetOrdinal("manv")),
                Matkhau = dataReader.IsDBNull(dataReader.GetOrdinal("matkhau")) ? null : dataReader.GetString(dataReader.GetOrdinal("matkhau")),
                Manhomquyen = dataReader.IsDBNull(dataReader.GetOrdinal("manhomquyen")) ? (int?)null : dataReader.GetInt32(dataReader.GetOrdinal("manhomquyen")),
                Tendangnhap = dataReader.IsDBNull(dataReader.GetOrdinal("tendangnhap")) ? null : dataReader.GetString(dataReader.GetOrdinal("tendangnhap")),
                Trangthai = dataReader.IsDBNull(dataReader.GetOrdinal("trangthai")) ? (int?)null : dataReader.GetInt32(dataReader.GetOrdinal("trangthai")),
                Otp = dataReader.IsDBNull(dataReader.GetOrdinal("otp")) ? null : dataReader.GetString(dataReader.GetOrdinal("otp")),
            };
        }
    }
}
