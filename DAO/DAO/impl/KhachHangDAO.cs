using DAO.impl;
using DAO.Mapper.impl;
using Entity;
using State.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public class KhachHangDAO : AbstractDAO<KhachHang>, IKhachHangDAO
    {
        private readonly KhachHangRowMapper _rowMapper = new KhachHangRowMapper();
        public void delete(long id)
        {
            String query = "update from khachhang set trangthai=@trangthai where makh=@makh";
            Update(query,0, id);
        }

        public List<KhachHang> FindLikeName(string name)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "tenkhachahang",
                Operation = "LIKE",
                Value = name,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "khachhang");
        }

        public List<KhachHang> GetAll()
        {
            return SearchBy(null, _rowMapper, "khachhang");
        }

        public long insert(KhachHang khachhang)
        {
            string query = @"
                INSERT INTO nhanvien
                (
                  makh,tenkhachhang,diachi,sdt,trangthai,ngaythamgia
                ) 
                VALUES 
                (
                   @makh,@tenkhachhang,@diachi,@sdt,@trangthai,@ngaythamgia
                );";
            return Save(query,
               khachhang.MakH,
               khachhang.TenKhachHang,
               khachhang.DiaChi,
               khachhang.Sdt,
               khachhang.TrangThai ?? (object)DBNull.Value,
               khachhang.NgayThamGia

            );
        }

        public void update(KhachHang khachhang)
        {
            string query = @"
            UPDATE nhanvien 
            SET 
              makh=@makh,
              tenkhachhang=@tenkhachhang,
              diachi=@diachi,
              sdt=@sdt,
              trangthai=@trangthai,
              ngaythamgia=@ngaythamgia
              WHERE 
              makh = @makh;";

            Update(query,
            khachhang.MakH,
               khachhang.TenKhachHang,
               khachhang.DiaChi,
               khachhang.Sdt,
               khachhang.TrangThai ?? (object)DBNull.Value,
               khachhang.NgayThamGia
            );
        }
    }
}
