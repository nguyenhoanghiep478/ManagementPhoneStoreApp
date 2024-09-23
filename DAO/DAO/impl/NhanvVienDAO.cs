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
    public class NhanvVienDAO : AbstractDAO<NhanVien>, INhanVienDAO
    {
        private readonly NhanViewRowMapper _rowMapper = new NhanViewRowMapper();
        public void delete(long id)
        {
            String query = "update from nhanvien set trangthai=@trangthai where manv=@manv";
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
                   @manv,@hoten,@giotinh,@ngaysinh,@sdt,@email,@trangthai
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
              manv=@manv,
              hoten=@hoten,
              gioitinh=@giotinh,
              ngaysinh=@ngaysinh,
              sdt=@sdt,
              email=@email,
              trangthai=@trangthai
              WHERE 
              manvv = @manv;";

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
