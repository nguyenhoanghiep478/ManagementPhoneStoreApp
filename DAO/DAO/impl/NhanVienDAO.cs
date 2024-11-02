using DAO.impl;
using DAO.Mapper.impl;
using Entity;
using State.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO.impl
{
    public class NhanVienDAO : AbstractDAO<NhanVien>, INhanVienDAO
    {
        private readonly NhanViewRowMapper _rowMapper = new NhanViewRowMapper();
        public void delete(long id)
        {
            String query = "update from nhanvien set trangthai=@param0 where manv=@param1";
            Update(query, 0, id);
        }

        public List<NhanVien> FindLikeName(string name)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "hoten",
                Operation = "LIKE",
                Value = name,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "nhanvien");
        }

        public List<NhanVien> GetAll()
        {
            return SearchBy(null, _rowMapper, "nhanvien");
        }

        public long insert(NhanVien nhanvien)
        {
            string query = @"
                INSERT INTO nhanvien
                (
                   manv,hoten,giotinh,ngaysinh,sdt,email,trangthai
                ) 
                VALUES 
                (
                  @param0, @param1, @param2, @param3, @param4, @param5,@param6
                );";
            return Save(query,
            nhanvien.Manv,
            nhanvien.Hoten,
            nhanvien.Giotinh ?? (object)DBNull.Value,
            nhanvien.Ngaysinh,
            nhanvien.Sdt ,
            nhanvien.Email,
            nhanvien.Trangthai ?? (object)DBNull.Value
            );
        }

        public void update(NhanVien nhanvien)
        {
            string query = @"
            UPDATE nhanvien 
            SET 
              hoten=@param1,
              gioitinh=@param2,
              ngaysinh=@param3,
              sdt=@param4,
              email=@param5,
              trangthai=@param6
              WHERE 
              manv = @param0;";

            Update(query,
            nhanvien.Manv,
            nhanvien.Hoten,
            nhanvien.Giotinh ?? (object)DBNull.Value,
            nhanvien.Ngaysinh,
            nhanvien.Sdt,
            nhanvien.Email,
            nhanvien.Trangthai ?? (object)DBNull.Value
            );
        }
    }
}
