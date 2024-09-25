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
    public class ChiTietPhieuXuatRowMapper : IRowMapper<ChiTietPhieuXuat>
    {
        public ChiTietPhieuXuat MapRow(IDataReader dataReader)
        {
            return new ChiTietPhieuXuat
            {
                Maphieuxuat = dataReader.GetInt32(dataReader.GetOrdinal("maphieuxuat")),
                Maphienbansp = dataReader.GetInt32(dataReader.GetOrdinal("maphienbansp")),
                Soluong = dataReader.GetInt32(dataReader.GetOrdinal("soluong")),
                Dongia = dataReader.GetInt32(dataReader.GetOrdinal("dongia"))
            };
        }
    }
}
